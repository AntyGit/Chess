   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Chess.ModelChess.Model  5   	   )clr-namespace:Chess.UtilsChess.Utils  5   	       Chess.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F   +localclr-namespace:Chess.Model     5   	   +utilsclr-namespace:Chess.Utils     5   	   -   5          �Name$  window��5   �    � Title$ 
MainWindow��5   	   $
��1280��6   $	��720��6)    � 	Resources 5      #   Chess.Utils.DataTypeConverter   DataTypeConverter  ChessPieceStyle �� 
TargetType �� Triggers ^� 
Conditions �� Value   Chess.Model.Pawn �� Binding �� 	Converter   Chess.Model.PlayerType	   Human
 �� Property �� Value   Chess.Model.Rook   Chess.Model.Knight   Chess.Model.Bishop   Chess.Model.Queen   Chess.Model.King	   AI��%�
  &	        &	      7   7   7   7   7   7   7   7   7   7   7   7     5   
   6"   �� 5   
   " ��6(    5      ^� 5       5      �� 5      "  6l    6$   �� *Type+8   6l   �� 5      # Z	 6?    6$   �� *Player+6?   0�5      �� 5      
 � ��$ Assets/W_PAWN.png��69   5      ^� 5       5      �� 5      "  6l    6$   �� *Type+8  6l   �� 5      # Z	 6?    6$   �� *Player+6?   0�5!      �� 5"      
 � ��$ Assets/W_ROOK.png��69   5$      ^� 5%       5&      �� 5'      "  6l    6$   �� *Type+8  6l   �� 5(      # Z	 6?    6$   �� *Player+6?   0�5*      �� 5+      
 � ��$ Assets/W_KNIGHT.png��69   5-      ^� 5.       5/      �� 50      "  6l    6$   �� *Type+8  6l   �� 51      # Z	 6?    6$   �� *Player+6?   0�53      �� 54      
 � ��$ Assets/W_BISHOP.png��69   56      ^� 57       58      �� 59      "  6l    6$   �� *Type+8  6l   �� 5:      # Z	 6?    6$   �� *Player+6?   0�5<      �� 5=      
 � ��$ Assets/W_QUEEN.png��69   5?      ^� 5@       5A      �� 5B      "  6l    6$   �� *Type+8  6l   �� 5C      # Z	 6?    6$   �� *Player+6?   0�5E      �� 5F      
 � ��$ Assets/W_KING.png��69   5H      ^� 5I       5J      �� 5K      "  6l    6$   �� *Type+8  6l   �� 5L      # Z 6?    6$   �� *Player+6?   0�5N      �� 5O      
 � ��$ Assets/B_PAWN.png��69   5Q      ^� 5R       5S      �� 5T      "  6l    6$   �� *Type+8  6l   �� 5U      # Z 6?    6$   �� *Player+6?   0�5W      �� 5X      
 � ��$ Assets/B_ROOK.png��69   5Z      ^� 5[       5\      �� 5]      "  6l    6$   �� *Type+8  6l   �� 5^      # Z 6?    6$   �� *Player+6?   0�5`      �� 5a      
 � ��$ Assets/B_KNIGHT.png��69   5c      ^� 5d       5e      �� 5f      "  6l    6$   �� *Type+8 	 6l   �� 5g      # Z 6?    6$   �� *Player+6?   0�5i      �� 5j      
 � ��$ Assets/B_BISHOP.png��69   5l      ^� 5m       5n      �� 5o      "  6l    6$   �� *Type+8 
 6l   �� 5p      # Z 6?    6$   �� *Player+6?   0�5r      �� 5s      
 � ��$ Assets/B_QUEEN.png��69   5u      ^� 5v       5w      �� 5x      "  6l    6$   �� *Type+8  6l   �� 5y      # Z 6?    6$   �� *Player+6?   0�5{      �� 5|      
 � ��$ Assets/B_KING.png��69   5~      5�      5�      .��5�      � -   5        $
��Grid��5�      .+�5�   
   ]� .+�5�      �� -   5         ��Name$ status��5�      $��20,0,0,0q�6C   ��6$   �� *
GameStatus+6C   o� 5�      $	��Top=�6   $��25��6(   .@�5�      m� $��_Game��6   .@�5�      m� -   5        $��_Reset��5�      6/   m� 5�      -   5        $��_Load��5�      6.   m� 5�      -   5        $��_Save��5�      6.   5�      5�      �� 5�      5�      5�      A� 5�   
   -   5         A�Name$ 	tile_grid��5�       A� Rows$ 8��6)    A� Columns$ 8��62   $��0,25,0,0q�6>   �� 5�   
   $��0,25,0,0q�6A   ��6   ��  �� Path$ Board.Pieces���5�      �� 5�      .R�5�      � $	��hje��6   ��6&   �� *tile_grid.ActualWidth+��6N   �� *tile_grid.ActualHeight+ � RowDefinitions 5�      �� 5�      $��* �6,   �� 5�      $��* �6,   �� 5�      $��* �6,   �� 5�      $��* �6,   �� 5�      $��* �6,   �� 5�      $��* �6,   �� 5�      $��* �6,   �� 5�      $��* �6,    � ColumnDefinitions 5�      �� 5�      $��* �6/   �� 5�      $��* �6/   �� 5�      $��* �6/   �� 5�      $��* �6/   �� 5�      $��* �6/   �� 5�      $��* �6/   �� 5�      $��* �6/   �� 5�      $��* �6/   5�      5�      ��5�      �� 5�      .R�5�      �� -   5        #��[ 5�      6E   5�      ��5�      �� 5�      .�5�      �� 
 � �� 61   �� *
Position.Y+�� 5�      
 � �� 64   �� *
Position.X+5�      5�      5�      5�      