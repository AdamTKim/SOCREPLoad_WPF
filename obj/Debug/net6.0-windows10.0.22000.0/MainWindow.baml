   M S B A M L   `   `   `  ????O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    SOCREPLoad_WPF   SOCREPLoad_WPF.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     ? Title$*  $Live Monitor Tool - SOCREP Generator??5   	   $
??1920??66   $
??1080??6C   $
??1220??6Q   $	??465??6a   $
??3840??6q   $
??2160??6?    ? WindowState$ 	Maximized=?6?    ? WindowStartupLocation$ CenterScreen=?6?   .??5
      ? -   5         ?Name$ 
socrepGrid??5
      ???#DBDBDB-  'System.Windows.Input.KeyboardNavigation   TabNavigation$ Continue=?64   .+?5   
   ?? $??	14,22,0,0q?6   $??assets/P5CTS_Icon.png??6#   $??Uniform=?6B   $	??Top=?6T   $
??Left=?6l   $	??150??6?   ?? 5   
   -   5         ??Name$ openFile_button??5      $??	Open File??6*   $??0,155,985,0q?6>   $	??Top=?6S   $??Right=?6k   $??75??6?   $??25??6?   $??16(?6?   
???????$??False??5   -   ??5      ?? 5       ?? 
TargetType" ??6   .?5      ??  ?? Property ? ?? ?? Value ?	#FF18458463   ?? 5       ? ?? 5      ?? 5      	 ?? 
TargetType"	 ??6.   .R?5   "   ?? #??z??6)   ._?5   &   ?? $??Center=?67   $??Center=?6T   5   #   5      5      
 ?? Triggers
 5      P? 5       P? Property ?@J?IsMouseOver P? Value$
 True??69   . ?5      ??  ? ??
 ?""??6;   5      5       5"      ?? 5$   
   -   5         ??Name$ mainWindowStatusBar??5$      $??0,0,0,0q?61   $??20??6B   $??Bottom=?6N   ???#4545446i   ?? 5%   
   -   5         ??Name$ rowCountHAA_label??5%      $??0??6+   $??Right=?67   $??
0,0,238,-3q?6S   $??Bottom=?6g   
???????$??14(?6?   ?? 5&   
   -   5        $ rowCountLAA_label??5&      $??0??6+   $??Right=?67   $??
0,0,135,-3q?6S   $??Bottom=?6g   
???????$??14(?6?   ?? 5'   
   -   5        $ rowCount_label??5'      $??0??6(   $??Right=?64   $??	0,0,40,-3q?6P   $??Bottom=?6c   
???????$??14(?6?   ?? 5(   
   $??: HAA??6   $??Right=?6    $??
0,0,200,-3q?6<   $??Bottom=?6P   
???????$??14(?6?   ?? 5)   
   $??: LAA??6   $??Right=?6    $??
0,0,100,-3q?6<   $??Bottom=?6P   
???????$??14(?6?   ?? 5*   
   $??: Total??6   $??Right=?6"   $??0,0,0,-3q?6>   $??Bottom=?6P   
???????$??14(?6?   ?? 5,   
   $??Sortie Mission ID??6   $??
0,15,796,0q?6,   $	??Top=?6@   $??Right=?6X   $	??174??6t   $??22(?6?   ?? 5-   
   $??-??6   $??
0,45,872,0q?6   $	??Top=?60   $??Right=?6H   $??20??6d   $??22(?6o   ?? 5.   
   $??Project Number??6   $??0,110,807,0q?6)   $	??Top=?6>   $??Right=?6V   $	??163??6r   $??22(?6~   ?? 5/   
   $??Sortie Date??6   $??
0,15,557,0q?6&   $	??Top=?6:   $??Right=?6R   $	??118??6n   $??22(?6z   ?? 50   
   $??# of CDs??6   $??0,110,515,0q?6#   $	??Top=?68   $??Right=?6P   $	??160??6l   $??22(?6x   ?? 51   
   $??Range Start Time??6   $??
0,15,305,0q?6+   $	??Top=?6?   $??Right=?6W   $	??175??6s   $??22(?6   ?? 52   
   $??-??6   $??
0,15,281,0q?6   $	??Top=?60   $??Right=?6H   $??20??6d   $??22(?6o   ?? 53   
   $??-??6   $??
0,45,281,0q?6   $	??Top=?60   $??Right=?6H   $??20??6d   $??22(?6o   ?? 54   
   $??Range End Time??6   $??
0,15,113,0q?6)   $	??Top=?6=   $??Right=?6U   $	??167??6q   $??22(?6}   ?? 55   
   $??Recorded Stations??6   $??0,110,330,0q?6,   $	??Top=?6A   $??Right=?6Y   $	??185??6u   $??22(?6?   ?? 57   
   -   5         ??Name$! sortieMissionIDJulian_input??57      $??
0,50,891,0q?67   $	??Top=?6K   $??Right=?6c    ?? TextWrapping$
 Wrap=?6   $??35??6?   $??75??6?   $??22(?6?   $??Center=?58       ?? 	MaxLength$ 5??67   $??False??6E    ?? 
IsReadOnly$
 True??6W   ?? 59   
   -   5        $ sortieMissionIDTime_input??59      $??
0,50,760,0q?65   $	??Top=?6I   $??Right=?6a   $
 Wrap=?6}   $??35??6?   $	??115??6?   $??22(?6?   $??Center=?5:      $ 7??67   $??1??6E   ?? 5;   
   -	   5        $ sortieStartTime_input??5;      $??
0,50,306,0q?61   $	??Top=?6E   $??Right=?6]   $
 Wrap=?6y   $??35??6?   $??55??6?   $??22(?6?   $??Center=?5<      $ 4??67   $??2??6E   6R   ?? 5=   
   -
   5        $ sortieEndTime_input??5=      $??
0,50,221,0q?6/   $	??Top=?6C   $??Right=?6[   $
 Wrap=?6w   $??35??6?   $??55??6?   $??22(?6?   $??Center=?5>      $ 4??67   $??3??6E   6R   ?? 5?   
   -   5        $ sortieProject_input??5?      $??0,145,791,0q?6/   $	??Top=?6D   $??Right=?6\   $
 Wrap=?6x   $??35??6?   $	??175??6?   $??22(?6?   $??Center=?5@      $ 8??67   $??4??6E   ?? 5A   
   -   5        $ sortieNumCD_input??5A      $??0,145,641,0q?6-   $	??Top=?6B   $??Right=?6Z   $
 Wrap=?6v   $??35??6?   $??30??6?   $??22(?6?   $??Center=?5B      $ 2??67   $??5??6E   6R   	? 5D   
   -   5         	?Name$ sortieDash1_input??5D      $
??(-1)??61   $??0,120,280,0q?6@   $	??Top=?6U   $??Right=?6m   $??18(?6?   $??Center=?6?   $??False??5E       d? 	IsChecked$
 TrueY?6+   	? 5F   
   -   5        $ sortieDash2_input??5F      $
??(-2)??61   $??0,120,230,0q?6@   $	??Top=?6U   $??Right=?6m   $??18(?6?   $??Center=?6?   $??False??5G      $ FalseY?6+   	? 5H   
   -   5        $ sortieDash3_input??5H      $
??(-3)??61   $??0,120,180,0q?6@   $	??Top=?6U   $??Right=?6m   $??18(?6?   $??Center=?6?   $??False??5I      $ FalseY?6+   ?? 5K   
   -   5         ??Name$ sortieStationM_input??5K      $??M??61   $??0,148,470,0q?6=   $	??Top=?6R   $??Right=?6j   $??40??6?   $??22(?6?   $??Center=?6?   $??6??5L      ?? 5M   
   -   5        $ sortieStation2_input??5M      $??2??61   $??0,148,420,0q?6=   $	??Top=?6R   $??Right=?6j   $??32??6?   $??22(?6?   $??Center=?6?   $??7??5N      ?? 5O   
   -   5        $ sortieStation3_input??5O      $??3??61   $??0,148,370,0q?6=   $	??Top=?6R   $??Right=?6j   $??32??6?   $??22(?6?   $??Center=?6?   $??8??5P      ?? 5Q   
   -   5        $ sortieStation4_input??5Q      $??4??61   $??0,148,320,0q?6=   $	??Top=?6R   $??Right=?6j   $??32??6?   $??22(?6?   $??Center=?6?   $??9??5R      ?? 5S   
   -   5        $ sortieStation5_input??5S      $??5??61   $??0,148,270,0q?6=   $	??Top=?6R   $??Right=?6j   $??32??6?   $??22(?6?   $??Center=?6?   $??10??5T      ?? 5U   
   -   5        $ sortieStation6_input??5U      $??6??61   $??0,148,220,0q?6=   $	??Top=?6R   $??Right=?6j   $??32??6?   $??22(?6?   $??Center=?6?   $??11??5V      ?? 5W   
   -   5        $ sortieStation7_input??5W      $??7??61   $??0,148,170,0q?6=   $	??Top=?6R   $??Right=?6j   $??32??6?   $??22(?6?   $??Center=?6?   $??12??5X      ?? 5Y   
   -   5        $ sortieStation8_input??5Y      $??8??61   $??0,148,120,0q?6=   $	??Top=?6R   $??Right=?6j   $??32??6?   $??22(?6?   $??Center=?6?   $??13??5Z      ?? 5[   
   -   5        $ sortieStation9_input??5[      $??9??61   $??
0,148,70,0q?6=   $	??Top=?6Q   $??Right=?6i   $??32??6?   $??22(?6?   $??Center=?6?   $??14??5\      ?? 5]   
   -   5        $ sortieStation10_input??5]      $??10??62   $??
0,148,10,0q?6?   $	??Top=?6S   $??Right=?6k   $??44??6?   $??22(?6?   $??Center=?6?   $??15??5^      (  "System.Windows.Controls.DatePicker  5`   
   -   5          Name$ sortieDate_input??5`      $??
0,50,521,0q?6/   $	??Top=?6C   $??Right=?6[   $??35??6w   $	??150??6?   $??22(?6?   $??Center=?6?   $
 None=?5a      
 ?? Now   SelectedDate# Z 6=   6?   ?? 5c   
   -   5        $ socrepExport_button??5c      $??Export SOCREP??6.   $??	0,0,10,30q?6F   $??Bottom=?6Y   $??Right=?6t   $??75??6?   $	??155??6?   $??20(?6?   
???????$??False??5d   -   ??5e      ?? 5f      " ??6   .?5g      ??  ? ?? ?	#FF18458463   ?? 5h       ? ?? 5i      ?? 5j      "	 ??6.   .R?5k   "   ?? #??z??6)   ._?5l   &   ?? $??Center=?67   $??Center=?6T   5m   #   5n      5p      
 5q      P? 5r       ?@J?IsMouseOver$
 True??69   . ?5s      ??  ? ??
 ?""??6;   5t      5v      5x      &   System.Windows.Controls.DataGrid  5z   
   -   5          Name$ socrepDG??5z      $??10,190,10,120q?6%    ?? AlternationCount$ 2??6<      AutoGenerateColumns$ False??6Q      CanUserResizeColumns$
 True??6m      CanUserReorderColumns$ False??6?      CanUserAddRows$ False??5{         CanUserResizeRows$ False??6.       
IsReadOnly$  False??6H   !   SelectionMode$! Extended=?6[   "   SelectionUnit$" FullRow=?6t   ???#E6E6E6#   HeadersVisibility$# Column=?6?   $
 None=?5|      $ ? 	Resources$ 5}      % ?? Color??%T   (??       5~   "   * SystemColors.HighlightBrushKey+)?? 6   $% #FFFE80??6T   5      & ? ContextMenu& 5?      ?? 5?      .@?5?      m? -   5        $??Select??5?      6/   m? 5?      -   5        $??Unselect??5?      61   5?      '   ColumnHeaderStyle' 5?      ?? 5?      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .?5?      ??  ? ??$ 22??6/   ?? 5?       ? ?? ?#FAF7FC63   ?? 5?       ? ?? ?#45454463   ?? 5?       ? ??$ Center=?6A   ?? 5?       ? ??$ Center=?6C   5?      (   RowStyle( 5?      ?? 5?      )  #System.Windows.Controls.DataGridRow"  6   .?5?      ??  ? ??$ 25??6/   
 5?      ^? 5?      ) ^? 
Conditions) 5?      ?? 5?   "   * ?? Binding* 6,   ?? *LowActSelect++ ?? Value	+ False6M   ?? 5?   "   * 6,   ?? *AlternationIndex+, ?? RelativeSource, ?? *Self++ 06w   .0?5?      ??  ? ?? ?#FFBB806;   5?      ^? 5?      ) 5?      ?? 5?   "   * 6,   ?? *LowActSelect+	+ False6M   ?? 5?   "   * 6,   ?? *AlternationIndex+, ?? *Self++ 16w   .0?5?      ??  ? ?? ?#FFA04D6;   5?      ^? 5?      ) 5?      ?? 5?   "   * 6,   ?? *LowActSelect++ True6M   ?? 5?   "   * 6,   ?? *AlternationIndex+, ?? *Self++ 06w   .0?5?      ??  ? ?? ?#8EC3F16;   5?      ^? 5?      ) 5?      ?? 5?   "   * 6,   ?? *LowActSelect++ True6M   ?? 5?   "   * 6,   ?? *AlternationIndex+, ?? *Self++ 16w   .0?5?      ??  ? ?? ?#60AAEB6;   5?      ^? 5?      ) 5?      ?? 5?   "   * 6,   ?? *Tailno++ MALD6G   ?? 5?   "   * 6,   ?? *AlternationIndex+, ?? *Self++ 06w   .0?5?      ??  ? ?? ?#B7A3DC6;   5?      ^? 5?      ) 5?      ?? 5?   "   * 6,   ?? *Tailno++ MALD6G   ?? 5?   "   * 6,   ?? *AlternationIndex+, ?? *Self++ 16w   .0?5?      ??  ? ?? ?#9A7ECE6;   5?      ^? 5?      ) 5?      ?? 5?   "   * 6,   ?? *
Selected++ True6I   ?? 5?   "   * 6,   ?? *AlternationIndex+, ?? *Self++ 06w   .0?5?      ??  ? ?? ?#99E6996;   5?      ^? 5?      ) 5?      ?? 5?   "   * 6,   ?? *
Selected++ True6I   ?? 5?   "   * 6,   ?? *AlternationIndex+, ?? *Self++ 16w   .0?5?      ??  ? ?? ?#70DB706;   5?      ^? 5?      ) 5?      ?? 5?   "   * 6,   ?? *	Submitted++ True6J   ?? 5?   "   * 6,   ?? *AlternationIndex+, ?? *Self++ 06w   .0?5?      ??  ? ?? ?#FF86806;   5?      ^? 5?      ) 5?      ?? 5?   "   * 6,   ?? *	Submitted++ True6J   ?? 5?   "   * 6,   ?? *AlternationIndex+, ?? *Self++ 16w   .0?5?      ??  ? ?? ?#FF554D6;   5?      5?      -   	CellStyle- 5?      ?? 5?      *  $System.Windows.Controls.DataGridCell"  6   .?5?      ??  ? ??
 ?   ?63   ?? 5?       ?@??TextAlignment$ Center=?6@   5?      .   Columns. 5?      4  .System.Windows.Controls.DataGridTemplateColumn  5?      ,  &System.Windows.Controls.DataGridColumn/   Width5	  /System.Windows.Controls.DataGridLengthConverter$	/ 100	 6)   0   Header0 5?      ?? 5?      -   5        $ selectAll_input??5?   #   $??
SELECT ALL??6<   $??Bottom=?6Q   ???#FAF7FC6?   1   CellTemplate1 5?      ?? 5?      .R?5?      ?? $ select_input??6'   -    5        $??9,5,0,0q?5?   =   $??Center=?6N   $??19??6i    6u   ?? *
Selected+2 ?? UpdateSourceTrigger$2 PropertyChanged=?6?   5?      5?      0
  *System.Windows.Controls.DataGridTextColumn
  5?      $
0 SLOT??6%   $/ *	 6q   3   
IsReadOnly$
3 True??6{   1  +System.Windows.Controls.DataGridBoundColumn4   Binding4 63   ?? *Slot+$2 PropertyChanged=?6{   
  5?      $0 	PILOTNAME??6%   $/ *	 6{   $
3 True??6?   4 68   ?? *	Pilotname+$2 PropertyChanged=?6?   
  5?      $0 CALLSIGN??6%   $/ *	 6y   $
3 True??6?   4 67   ?? *
Callsign+$2 PropertyChanged=?6?   
  5?      $0 ACTYPE??6%   $/ *	 6u   $
3 True??6   4 65   ?? *ACType+$2 PropertyChanged=?6   
  5?      $0 TAILNO??6%   $/ *	 6u   $
3 True??6   4 65   ?? *Tailno+$2 PropertyChanged=?6   
  5?      $
0 PSID??6%   $/ *	 6q   $
3 True??6{   4 63   ?? *PSID+$2 PropertyChanged=?6{   
  5?      $	0 IFF??6%   $/ *	 6o   $
3 True??6y   4 62   ?? *IFF+$2 PropertyChanged=?6y     5?      $	/ 125	 6)   0 5?      ?? 5?      -!   5        $ lowActSelectAll_input??5?   #   $??SELECT ALL LAA??6B   $??Bottom=?6[   ???#FAF7FC$??RightToLeft=?6?   6?   1 5?      ?? 5?      .R?5?      ?? $ lowActSelect_input??6'   -"   5        $??0,5,8,0q?5?   C   $??Center=?6T   $??19??6o   $??RightToLeft=?6{    6?   ?? *LowActSelect+$2 PropertyChanged=?6?   5?      5?      5?      5      5     