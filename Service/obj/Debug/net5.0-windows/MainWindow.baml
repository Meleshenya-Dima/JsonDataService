   M S B A M L   `   `   `  ????B  >Service, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Service.ApplicationViewModelService.ApplicationViewModel  5   	   l hSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=null?{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting 5   	       Service.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Kapplicationviewmodel*clr-namespace:Service.ApplicationViewModel     5   	   ?charting{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	     ? Title$  
MainWindow??5
   	   $	??448??6   $	??800??6)   .??5      ? $??0,-6,0,0q?6    ? ColumnDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $
??0.8* ?6   .+?5   
   ?? $??0??6   $??
0,10,169,0q?5   8   ??5   "   ?? *Users+ ?? SelectedItem 5      ?? *SelectedUser+??5      ?? 5      .R?5      ?? $??5q?6!   .+?5      ?? $??18(?6$   ??62   ??  ?? Path$
 User?5      ?? 5      $6??0Средний результат по дням:??6$   ?? 5      ??6$   ?? $ AverageResult??? 5      $&?? Лучший результат:??6$   ?? 5      ??6%   ?? $ 
BestResult??? 5      $&?? Худший результат:??6$   ?? 5      ??6$   ?? $ WorstResult?5      5      ??5       ?? 5!       ?? 
TargetType" ??6    ?? Triggers 5"      ?? 5#       ?? Binding 6&   ?? $ 
Difference? ?? Value true6J   .a?5$      ??  ?? Property ? ??	 ?? Value
	 ??  ?6;   5%      5'      5)      >  8System.Windows.Controls.DataVisualization.Charting.Chart  5*   
   -   5        $??Charts??5*      $??280,13,-18,0q?6'   $??2??6=   
???????
   Series.
 5+      C  =System.Windows.Controls.DataVisualization.Charting.LineSeries  -   5        $??Point??5+   "   ?  9System.Windows.Controls.DataVisualization.Charting.Series   Title$ Point (WithValue)??6/   H  BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   DependentValuePath$ Value??6I      IndependentValuePath$	 Day??6d   $
??Left=?6?   $	??340??6?      ItemsSource 6   ?? *SelectedUserDay+6?      Axes 5.      C  =System.Windows.Controls.DataVisualization.Charting.LinearAxis  =  7System.Windows.Controls.DataVisualization.Charting.Axis   Orientation$ Y=?6&   D  >System.Windows.Controls.DataVisualization.Charting.NumericAxis   Minimum?  ?System.Windows.Controls.DataVisualization.Charting.NullableConverter`1[[System.Double, System.Runtime, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]$ 0 66      Maximum$ 120000 6B     5/      $ X=?6&   $ 0 66   $ 30 6B   D	  >System.Windows.Controls.DataVisualization.Charting.DisplayAxis 	  ShowGridLines$
 True??6O   51      ?? 52   
   $
??Save??6   $
??Left=?6    $??
280,13,0,0q?6;   $	??Top=?6O    J? RenderTransformOrigin$ -0.264,-0.549&?6g   $??67??6?   ??6?   ?? *SaveCommand+??6?   ?? *SelectedUser+?? 53   
   $#??Смотреть график??6   $??1??6+   $
??Left=?6;   $??231,260,0,0q?6V   $	??Top=?6k   $ 0.241,0.002&?6?   ??6?   ?? *GraficValue+??6?   ?? *SelectedUser+?? 54   
   $4??.График для пользователя: ??6   $
??Left=?64   $??
381,35,0,0q?6O   $	??Top=?6c   $??2??6{   $	??154??6?   55      56      