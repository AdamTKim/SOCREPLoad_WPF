   M S B A M L   `   `   `  ????O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    SOCREPLoad_WPF   SOCREPLoad_WPF.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     ? Title$  SOCREP Generator??5   	   $
??1920??6"   $
??1080??6/   $
??1550??6=   $	??750??6M    ? WindowState$ 	Maximized=?6]   .??5
      ? -   5         ?Name$ 
socrepGrid??5
      ???#DBDBDB-  'System.Windows.Input.KeyboardNavigation   TabNavigation$ Continue=?64   .+?5   
   ?? $??	14,22,0,0q?6   $??assets/P5CTS_Icon.png??6#   $??Uniform=?6B   $	??Top=?6T   $
??Left=?6l   $	??150??6?   ?? 5   
   -   5         ??Name$ openFile_button??5      $??	Open File??6*   $??0,155,1000,0q?6>   $	??Top=?6T   $??Right=?6l   $??75??6?   $??25??6?   $??16(?6?   
???????$??False??5   -   ??5      ?? 5       ?? 
TargetType" ??6   .?5      ??  ?? Property ? ?? ?? Value ?	#FF18458463   ?? 5       ? ?? 5      ?? 5       ?? 
TargetType" ??6.   .R?5   "   ?? #??z??6)   ._?5   &   ?? $??Center=?67   $??Center=?6T   5   #   5      5      	 ?? Triggers	 5      P? 5      
 P? Property
 ?@J?IsMouseOver P? Value$
 True??69   . ?5      ??  ? ??
 ?""??6;   5      5       5"      ?? 5$   
   -   5         ??Name$ mainWindowStatusBar??5$      $??0,0,0,0q?61   $??20??6B   $??Bottom=?6N   ???#4545446i   ?? 5%   
   -   5         ??Name$ rowCount_label??5%      $??0??6(   $??Right=?64   $??
0,0,112,-3q?6P   $??Bottom=?6d   
???????$??14(?6?   ?? 5&   
   $??: Aircraft in Sortie??6   $??Right=?6/   $??0,0,0,-3q?6K   $??Bottom=?6]   
???????$??14(?6?   ?? 5(   
   $??Sortie Mission ID??6   $??
0,15,791,0q?6,   $	??Top=?6@   $??Right=?6X   $	??174??6t   $??22(?6?   ?? 5)   
   $??-??6   $??
0,45,867,0q?6   $	??Top=?60   $??Right=?6H   $??20??6d   $??22(?6o   ?? 5*   
   $??Project Number??6   $??0,110,802,0q?6)   $	??Top=?6>   $??Right=?6V   $	??163??6r   $??22(?6~   ?? 5+   
   $??Sortie Date??6   $??
0,15,557,0q?6&   $	??Top=?6:   $??Right=?6R   $	??118??6n   $??22(?6z   ?? 5,   
   $??# of CDs??6   $??0,110,515,0q?6#   $	??Top=?68   $??Right=?6P   $	??160??6l   $??22(?6x   ?? 5-   
   $??Range Start Time??6   $??
0,15,305,0q?6+   $	??Top=?6?   $??Right=?6W   $	??175??6s   $??22(?6   ?? 5.   
   $??-??6   $??
0,15,281,0q?6   $	??Top=?60   $??Right=?6H   $??20??6d   $??22(?6o   ?? 5/   
   $??-??6   $??
0,45,281,0q?6   $	??Top=?60   $??Right=?6H   $??20??6d   $??22(?6o   ?? 50   
   $??Range End Time??6   $??
0,15,113,0q?6)   $	??Top=?6=   $??Right=?6U   $	??167??6q   $??22(?6}   ?? 51   
   $??Recorded Stations??6   $??0,110,330,0q?6,   $	??Top=?6A   $??Right=?6Y   $	??185??6u   $??22(?6?   ?? 53   
   -   5         ??Name$! sortieMissionIDJulian_input??53      $??
0,50,886,0q?67   $	??Top=?6K   $??Right=?6c    ?? TextWrapping$
 Wrap=?6   $??35??6?   $??75??6?   $??22(?6?   $??Center=?54       ?? 	MaxLength$ 5??67   $??False??6E    ?? 
IsReadOnly$
 True??6W   ?? 55   
   -   5        $ sortieMissionIDTime_input??55      $??
0,50,760,0q?65   $	??Top=?6I   $??Right=?6a   $
 Wrap=?6}   $??35??6?   $	??110??6?   $??22(?6?   $??Center=?56      $ 5??67   $??1??6E   ?? 57   
   -   5        $ sortieStartTime_input??57      $??
0,50,306,0q?61   $	??Top=?6E   $??Right=?6]   $
 Wrap=?6y   $??35??6?   $??55??6?   $??22(?6?   $??Center=?58      $ 4??67   $??2??6E   6R   ?? 59   
   -   5        $ sortieEndTime_input??59      $??
0,50,221,0q?6/   $	??Top=?6C   $??Right=?6[   $
 Wrap=?6w   $??35??6?   $??55??6?   $??22(?6?   $??Center=?5:      $ 4??67   $??3??6E   6R   ?? 5;   
   -	   5        $ sortieProject_input??5;      $??0,145,786,0q?6/   $	??Top=?6D   $??Right=?6\   $
 Wrap=?6x   $??35??6?   $	??175??6?   $??22(?6?   $??Center=?5<      $ 8??67   $??4??6E   ?? 5=   
   -
   5        $ sortieNumCD_input??5=      $??0,145,641,0q?6-   $	??Top=?6B   $??Right=?6Z   $
 Wrap=?6v   $??35??6?   $??30??6?   $??22(?6?   $??Center=?5>      $ 2??67   $??5??6E   6R   	? 5@   
   -   5         	?Name$ sortieDash1_input??5@      $
??(-1)??61   $??0,120,280,0q?6@   $	??Top=?6U   $??Right=?6m   $??18(?6?   $??Center=?6?   $??False??5A       d? 	IsChecked$
 TrueY?6+   	? 5B   
   -   5        $ sortieDash2_input??5B      $
??(-2)??61   $??0,120,230,0q?6@   $	??Top=?6U   $??Right=?6m   $??18(?6?   $??Center=?6?   $??False??5C      $ FalseY?6+   	? 5D   
   -   5        $ sortieDash3_input??5D      $
??(-3)??61   $??0,120,180,0q?6@   $	??Top=?6U   $??Right=?6m   $??18(?6?   $??Center=?6?   $??False??5E      $ FalseY?6+   ?? 5G   
   -   5         ??Name$ sortieStationM_input??5G      $??M??61   $??0,148,470,0q?6=   $	??Top=?6R   $??Right=?6j   $??40??6?   $??22(?6?   $??Center=?6?   $??6??5H      ?? 5I   
   -   5        $ sortieStation2_input??5I      $??2??61   $??0,148,420,0q?6=   $	??Top=?6R   $??Right=?6j   $??32??6?   $??22(?6?   $??Center=?6?   $??7??5J      ?? 5K   
   -   5        $ sortieStation3_input??5K      $??3??61   $??0,148,370,0q?6=   $	??Top=?6R   $??Right=?6j   $??32??6?   $??22(?6?   $??Center=?6?   $??8??5L      ?? 5M   
   -   5        $ sortieStation4_input??5M      $??4??61   $??0,148,320,0q?6=   $	??Top=?6R   $??Right=?6j   $??32??6?   $??22(?6?   $??Center=?6?   $??9??5N      ?? 5O   
   -   5        $ sortieStation5_input??5O      $??5??61   $??0,148,270,0q?6=   $	??Top=?6R   $??Right=?6j   $??32??6?   $??22(?6?   $??Center=?6?   $??10??5P      ?? 5Q   
   -   5        $ sortieStation6_input??5Q      $??6??61   $??0,148,220,0q?6=   $	??Top=?6R   $??Right=?6j   $??32??6?   $??22(?6?   $??Center=?6?   $??11??5R      ?? 5S   
   -   5        $ sortieStation7_input??5S      $??7??61   $??0,148,170,0q?6=   $	??Top=?6R   $??Right=?6j   $??32??6?   $??22(?6?   $??Center=?6?   $??12??5T      ?? 5U   
   -   5        $ sortieStation8_input??5U      $??8??61   $??0,148,120,0q?6=   $	??Top=?6R   $??Right=?6j   $??32??6?   $??22(?6?   $??Center=?6?   $??13??5V      ?? 5W   
   -   5        $ sortieStation9_input??5W      $??9??61   $??
0,148,70,0q?6=   $	??Top=?6Q   $??Right=?6i   $??32??6?   $??22(?6?   $??Center=?6?   $??14??5X      ?? 5Y   
   -   5        $ sortieStation10_input??5Y      $??10??62   $??
0,148,10,0q?6?   $	??Top=?6S   $??Right=?6k   $??44??6?   $??22(?6?   $??Center=?6?   $??15??5Z      (  "System.Windows.Controls.DatePicker  5\   
   -   5          Name$ sortieDate_input??5\      $??
0,50,521,0q?6/   $	??Top=?6C   $??Right=?6[   $??35??6w   $	??150??6?   $??22(?6?   $??Center=?6?   $
 None=?5]      
 ?? Now   SelectedDate# Z 6=   6?   &   System.Windows.Controls.DataGrid  5_   
   -   5          Name$ 	socrep_dg??5_      $??10,200,10,120q?6&      AutoGenerateColumns$ False??6=      CanUserResizeColumns$
 True??6Y      CanUserReorderColumns$
 True??6u      CanUserAddRows$ False??5`         CanUserResizeRows$ False??6.      
IsReadOnly$
 True??6H      SelectionMode$ Single=?6Z       SelectionUnit$  FullRow=?6q   ???#E6E6E6!   HeadersVisibility$! Column=?6?   $
 None=?5a      " ? 	Resources" 5b      # ?? Color??%T   (??       5c   "   * SystemColors.HighlightBrushKey+)?? 6   $# #FFFE80??6T   5d      $   ColumnHeaderStyle$ 5e      ?? 5f      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .?5g      ??  ? ??$ Center=?6C   ?? 5h       ? ??$ Center=?6A   ?? 5i       ? ?? ?#45454463   ?? 5j       ? ?? ?#FAF7FC63   5k      %   	CellStyle% 5m      ?? 5n      *  $System.Windows.Controls.DataGridCell"  6   .?5o      ??  ?@??TextAlignment$ Center=?6@   ?? 5p       ? ??$ Center=?6:   ?? 5q       ? ??
 ?   ?63   5r      &   Columns& 5t      4  .System.Windows.Controls.DataGridCheckBoxColumn  5u      ,  &System.Windows.Controls.DataGridColumn'   Header$' SELECT??6)   (   Width5  /System.Windows.Controls.DataGridLengthConverter$( * 6y   1	  +System.Windows.Controls.DataGridBoundColumn) 	  Binding) 69   ?? *Select+* ?? UpdateSourceTrigger$* PropertyChanged=?+ 	  ElementStyle+ 5v      ?? 5w      " ??6    .?5x      ??  ? ??$ 0,4,0,0q?67   ?? 5y       ? ??$ 25??67   ?? 5z       ? ??$ Center=?6B   ?? 5{       ? ??$ Center=?6D   5|      5~      0
  *System.Windows.Controls.DataGridTextColumn
  5      $
' SLOT??6%   $( * 6q   ) 63   ?? *Slot+$* PropertyChanged=?+ 5?      ?? 5?      " ??6    .?5?      ??  ? ??$ 0,4,0,0q?67   ?? 5?       ? ??$ 25??67   ?? 5?       ? ??$ Center=?6B   ?? 5?       ? ??$ Center=?6D   5?      5?      
  5?      $' 	PILOTNAME??6%   $( * 6{   ) 68   ?? *	Pilotname+$* PropertyChanged=?+ 5?      ?? 5?      " ??6    .?5?      ??  ? ??$ 0,4,0,0q?67   ?? 5?       ? ??$ 25??67   ?? 5?       ? ??$ Center=?6B   ?? 5?       ? ??$ Center=?6D   5?      5?      
  5?      $' CALLSIGN??6%   $( * 6y   ) 67   ?? *
Callsign+$* PropertyChanged=?+ 5?      ?? 5?      " ??6    .?5?      ??  ? ??$ 0,4,0,0q?67   ?? 5?       ? ??$ 25??67   ?? 5?       ? ??$ Center=?6B   ?? 5?       ? ??$ Center=?6D   5?      5?      
  5?      $' ACTYPE??6%   $( * 6u   ) 65   ?? *ACType+$* PropertyChanged=?+ 5?      ?? 5?      " ??6    .?5?      ??  ? ??$ 0,4,0,0q?67   ?? 5?       ? ??$ 25??67   ?? 5?       ? ??$ Center=?6B   ?? 5?       ? ??$ Center=?6D   5?      5?      
  5?      $' TAILNO??6%   $( * 6u   ) 65   ?? *Tailno+$* PropertyChanged=?+ 5?      ?? 5?      " ??6    .?5?      ??  ? ??$ 0,4,0,0q?67   ?? 5?       ? ??$ 25??67   ?? 5?       ? ??$ Center=?6B   ?? 5?       ? ??$ Center=?6D   5?      5?      
  5?      $
' PSID??6%   $( * 6q   ) 63   ?? *PSID+$* PropertyChanged=?+ 5?      ?? 5?      " ??6    .?5?      ??  ? ??$ 0,4,0,0q?67   ?? 5?       ? ??$ 25??67   ?? 5?       ? ??$ Center=?6B   ?? 5?       ? ??$ Center=?6D   5?      5?      
  5?      $	' IFF??6%   $( * 6o   ) 62   ?? *IFF+$* PropertyChanged=?+ 5?      ?? 5?      " ??6    .?5?      ??  ? ??$ 0,4,0,0q?67   ?? 5?       ? ??$ 25??67   ?? 5?       ? ??$ Center=?6B   ?? 5?       ? ??$ Center=?6D   5?      5?      5?      5?      5?      