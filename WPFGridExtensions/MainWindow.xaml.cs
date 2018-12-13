using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFGridExtensions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public static class GridExtensions
    {
        public static string GetStructure(DependencyObject obj)
        {
            return (string)obj.GetValue(StructureProperty);
        }

        public static void SetStructure(DependencyObject obj, string value)
        {
            obj.SetValue(StructureProperty, value);
        }

        // Using a DependencyProperty as the backing store for Structure.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StructureProperty =
            DependencyProperty.RegisterAttached("Structure", typeof(string), typeof(GridExtensions), new PropertyMetadata("*|*", OnStructureChanged));

        private static void OnStructureChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Grid grid)
            {
                var converter = new GridLengthConverter();
                grid.RowDefinitions.Clear();
                grid.ColumnDefinitions.Clear();

                if (e.NewValue is string structureString)
                {
                    var rowsAndColumns = structureString.Split('|');
                    if (rowsAndColumns.Length == 2)
                    {
                        var rows = rowsAndColumns[0].Split(',');
                        foreach (var row in rows)
                        {
                            grid.RowDefinitions.Add(new RowDefinition { Height = (GridLength)converter.ConvertFromString(row) });
                        }

                        var columns = rowsAndColumns[1].Split(',');
                        foreach (var column in columns)
                        {
                            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = (GridLength)converter.ConvertFromString(column) });
                        }
                    }
                }
            }
        }
    }

}
