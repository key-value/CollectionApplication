using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CollectionApplication
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<BoolStringClass> TheList { get; set; }
        public MainWindow()
        {
            InitializeComponent(); 
            TheList = new ObservableCollection<BoolStringClass>();
            TheList.Add(new BoolStringClass { IsSelected = true, TheText = "Some text for item #1" });
            TheList.Add(new BoolStringClass { IsSelected = false, TheText = "Some text for item #2" });
            TheList.Add(new BoolStringClass { IsSelected = false, TheText = "Some text for item #3" });
            TheList.Add(new BoolStringClass { IsSelected = false, TheText = "Some text for item #4" });
            TheList.Add(new BoolStringClass { IsSelected = false, TheText = "Some text for item #5" });
            TheList.Add(new BoolStringClass { IsSelected = true, TheText = "Some text for item #6" });
            TheList.Add(new BoolStringClass { IsSelected = false, TheText = "Some text for item #7" });
        }
    }
    public class BoolStringClass
    {
        public string TheText { get; set; }
        public bool IsSelected { get; set; }
    }
}
