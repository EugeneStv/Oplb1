using FontAwesome.Sharp;
using opl4.Plugins;
using System.Diagnostics;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace opl4
{
    public partial class Form1 : Form
    {
        private List<ICloudStorageProvider> cldproviders = new List<ICloudStorageProvider>();
        private const int ICON_SIZE = 22;
        private const int ICON_MARGIN = 4;
        private Stack<string> foldersStack = new Stack<string>();
        private string CurrentFolderId => foldersStack.Count > 0 ? foldersStack.Peek() : "root";

        public Form1()
        {
            InitializeComponent();
            LoadPlugins();
            InitializeUI();
        }

        private void ListFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NavigateToSelectedItem();
            }
        }

        private void NavigateToSelectedItem()
        {
            if (listFiles.SelectedIndex == -1) return;

            var provider = cldproviders[cmbProviders.SelectedIndex];
            var cloudFiles = provider.GetFiles(foldersStack.Count > 0 ? foldersStack.Peek() : provider.RootFolderId);

            int selectedIndex = listFiles.SelectedIndex;
            bool isUpNavigation = (selectedIndex == 0 && foldersStack.Count > 0);

            if (isUpNavigation)
            {
                foldersStack.Pop();
            }
            else
            {
                int fileIndex = selectedIndex - (foldersStack.Count > 0 ? 1 : 0);
                if (fileIndex >= 0 && fileIndex < cloudFiles.Count)
                {
                    var selectedFile = cloudFiles[fileIndex];
                    if (selectedFile.IsDirectory)
                    {
                        foldersStack.Push(selectedFile.Path);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            RefreshFileList();
        }

        private void ListFiles_DoubleClick(object sender, EventArgs e)
        {
            NavigateToSelectedItem();
        }

        private void ListFiles_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop)
                ? DragDropEffects.Copy
                : DragDropEffects.None;
        }

        private void ListFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            var provider = cldproviders[cmbProviders.SelectedIndex];

            try
            {
                foreach (string filePath in files)
                {
                    if (File.Exists(filePath))
                    {
                        provider.UploadFile(filePath, CurrentFolderId);
                    }
                    else if (Directory.Exists(filePath))
                    {
                        UploadDirectory(provider, filePath, CurrentFolderId);
                    }
                }
                RefreshFileList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }
        }

        private void UploadDirectory(ICloudStorageProvider provider, string dirPath, string parentFolderId)
        {
            string dirName = Path.GetFileName(dirPath);
            string cloudDirId = provider.CreateFolder(parentFolderId, dirName);

            foreach (string file in Directory.GetFiles(dirPath))
            {
                provider.UploadFile(file, cloudDirId);
            }

            foreach (string subDir in Directory.GetDirectories(dirPath))
            {
                UploadDirectory(provider, subDir, cloudDirId);
            }
        }

        private void InitializeContextMenu()
        {
            var menu = new ContextMenuStrip();

            var downloadItem = new ToolStripMenuItem("Скачать");
            downloadItem.Click += (s, e) => DownloadSelectedFiles();
            menu.Items.Add(downloadItem);

            var deleteItem = new ToolStripMenuItem("Удалить");
            deleteItem.Click += async (s, e) =>
            {
                if (MessageBox.Show("Удалить выбранные файлы?", "Подтверждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    await DeleteSelectedFilesAsync();
                }
            };
            menu.Items.Add(deleteItem);

            var renameItem = new ToolStripMenuItem("Переименовать");
            renameItem.Click += async (s, e) => await RenameSelectedFileAsync();
            menu.Items.Add(renameItem);

            listFiles.ContextMenuStrip = menu;
        }

        private async Task DeleteSelectedFilesAsync()
        {
            if (listFiles.SelectedItems.Count == 0) return;

            var provider = cldproviders[cmbProviders.SelectedIndex];
            var cloudFiles = provider.GetFiles(CurrentFolderId);

            try
            {
                foreach (int index in listFiles.SelectedIndices)
                {
                    if (index == 0 && foldersStack.Count > 0) continue;

                    int fileIndex = index - (foldersStack.Count > 0 ? 1 : 0);
                    if (fileIndex >= 0 && fileIndex < cloudFiles.Count)
                    {
                        await Task.Run(() => provider.DeleteFile(cloudFiles[fileIndex].Path));
                    }
                }
                RefreshFileList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}");
            }
        }

        private async Task RenameSelectedFileAsync()
        {
            if (listFiles.SelectedItems.Count != 1) return;

            int index = listFiles.SelectedIndex;
            if (index == 0 && foldersStack.Count > 0) return;

            var provider = cldproviders[cmbProviders.SelectedIndex];
            var cloudFiles = provider.GetFiles(CurrentFolderId);
            int fileIndex = index - (foldersStack.Count > 0 ? 1 : 0);

            if (fileIndex < 0 || fileIndex >= cloudFiles.Count) return;

            var file = cloudFiles[fileIndex];
            string newName = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите новое имя:", "Переименование", file.Name);

            if (!string.IsNullOrEmpty(newName) && newName != file.Name)
            {
                try
                {
                    await Task.Run(() => provider.RenameFile(file.Path, newName));
                    RefreshFileList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка переименования: {ex.Message}");
                }
            }
        }


        private void ListFiles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop)
                ? DragDropEffects.Copy
                : DragDropEffects.None;
        }

        private void DownloadSelectedFiles()
        {
            if (cmbProviders.SelectedIndex == -1) return;

            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    var provider = cldproviders[cmbProviders.SelectedIndex];
                    var cloudFiles = provider.GetFiles(CurrentFolderId);

                    foreach (int index in listFiles.SelectedIndices)
                    {
                        if (index == 0) continue; // Пропускаем ".."
                        var file = cloudFiles[index - 1];
                        if (!file.IsDirectory)
                        {
                            string localPath = Path.Combine(folderDialog.SelectedPath, file.Name);
                            provider.DownloadFile(file.Path, localPath);
                        }
                    }
                }
            }
        }
        private (IconChar icon, Color color) GetFileIconInfo(string text, bool isDirectory, bool isUp)
        {
            if (isUp) return (IconChar.ArrowUp, Color.Blue);
            if (isDirectory) return (IconChar.Folder, Color.Goldenrod);

            string fileName = ExtractFileName(text);
            string ext = Path.GetExtension(fileName).ToLower();

            return ext switch
            {
                ".pdf" => (IconChar.FilePdf, Color.Red),
                ".docx" => (IconChar.FileWord, Color.RoyalBlue),
                ".xlsx" => (IconChar.FileExcel, Color.ForestGreen),
                ".zip" => (IconChar.FileArchive, Color.Orange),
                ".rar" => (IconChar.FileArchive, Color.Orange),
                ".exe" => (IconChar.Cogs, Color.DarkGray),
                ".txt" => (IconChar.FileAlt, Color.Gray),
                _ => (IconChar.File, Color.Gray)
            };
        }
        private string ExtractFileName(string text)
        {
            var match = Regex.Match(text, @"^(.*?)\s*\([0-9.]+\s*[KMG]?B\)$");
            return match.Success ? match.Groups[1].Value : text;
        }


        private void ListFiles_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            string text = listFiles.Items[e.Index].ToString();
            bool isDirectory = text.StartsWith("[Папка]");
            bool isUp = text == "..";

            (IconChar iconChar, Color color) = GetFileIconInfo(text, isDirectory, isUp);

            using (var iconImage = iconChar.ToBitmap(color, ICON_SIZE))
            {
                e.Graphics.DrawImage(iconImage, e.Bounds.Left + ICON_MARGIN, e.Bounds.Top + ICON_MARGIN, ICON_SIZE, ICON_SIZE);
            }

            using (var brush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(
                    text,
                    e.Font,
                    brush,
                    e.Bounds.Left + ICON_SIZE + ICON_MARGIN * 2,
                    e.Bounds.Top + ICON_MARGIN);
            }

            e.DrawFocusRectangle();
        }

        private void RefreshFileList()
        {
            if (cmbProviders.SelectedIndex == -1) return;

            listFiles.Items.Clear(); 

            try
            {
                var provider = cldproviders[cmbProviders.SelectedIndex];
                string currentPath = foldersStack.Count > 0 ? foldersStack.Peek() : provider.RootFolderId;
                currentPath = provider.NormalizePath(currentPath);


                var files = provider.GetFiles(currentPath);

                if (foldersStack.Count > 0)
                    listFiles.Items.Add("..");

                foreach (var file in files)
                {
                    string itemText = file.IsDirectory
                        ? $"[Папка] {file.Name}"
                        : $"{file.Name} ({FormatSize(file.Size)})";

                    listFiles.Items.Add(itemText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления списка файлов: {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string FormatSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            int order = 0;
            while (bytes >= 1024 && order < sizes.Length - 1)
            {
                order++;
                bytes /= 1024;
            }
            return $"{bytes:0.##} {sizes[order]}";
        }

        private void LoadPlugins()
        {
            string pluginsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");

            if (!Directory.Exists(pluginsDir))
            {
                MessageBox.Show("Папка Plugins не найдена");
                return;
            }

            cldproviders.Clear();

            foreach (string dllPath in Directory.GetFiles(pluginsDir, "*.dll"))
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(dllPath);

                    foreach (Type type in assembly.GetTypes())
                    {
                        if (typeof(ICloudStorageProvider).IsAssignableFrom(type) && !type.IsInterface)
                        {
                            var provider = (ICloudStorageProvider)Activator.CreateInstance(type);
                            cldproviders.Add(provider);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки плагина {Path.GetFileName(dllPath)}: {ex.Message}");
                }
            }
            cmbProviders.Items.Clear();
            foreach (var provider in cldproviders)
            {
                cmbProviders.Items.Add(provider.ProviderName);
            }
            if (cmbProviders.Items.Count > 0)
                cmbProviders.SelectedIndex = 0;
        }


        private void OnPluginChanged(object sender, FileSystemEventArgs e)
        {
            this.Invoke(new Action(() => LoadPlugins()));
        }

        private void OnPluginRenamed(object sender, RenamedEventArgs e)
        {
            this.Invoke(new Action(() => LoadPlugins()));
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cmbProviders.SelectedIndex == -1) return;
            foldersStack.Clear();
            try
            {
                var provider = cldproviders[cmbProviders.SelectedIndex];
                provider.Connect();
                MessageBox.Show($"Подключено: {provider.ProviderName}", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshFileList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshFileList();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbProviders.SelectedIndex == -1)
            {
                MessageBox.Show("Сначала выберите облачное хранилище");
                return;
            }

            var provider = cldproviders[cmbProviders.SelectedIndex];
            string currentPath = foldersStack.Count > 0 ? foldersStack.Peek() : provider.RootFolderId;

            string folderName = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите имя новой папки:",
                "Создание папки",
                "Новая папка");

            if (!string.IsNullOrWhiteSpace(folderName))
            {
                try
                {
                    string newFolderPath = provider.CreateFolder(currentPath, folderName);
                    RefreshFileList();

                    MessageBox.Show($"Папка '{folderName}' успешно создана");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при создании папки: {ex.Message}");
                }
            }
        }
    }
}
