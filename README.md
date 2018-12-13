# Wpf-Grid-Extensions
Contains a little extension for the WPF Grid to create RowDefinitions and ColumnDefinitions with a shorthand syntax

Instead of creating RowDefinitions and ColumnDefinitions like this:

```
<Grid>
  <Grid.RowDefinitions>
    <RowDefinition Height="*"/>
    <RowDefinition Height="100"/>
  </Grid.RowDefinitions>
  <Grid.ColumnDefinitions>
    <ColumnDefinition Width="200"/>
    <ColumnDefinition Width="*"/>
  </Grid.ColumnDefinitions>
  
</Grid>
```
this project contains an attached property to create them like this:
```
<Grid local:GridExtensions.Structure="*,100|200,*">

</Grid>
```
