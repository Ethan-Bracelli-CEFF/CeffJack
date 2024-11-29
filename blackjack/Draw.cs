using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    public class Draw
    {
        public void DrawTitle()
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("        CCCCCCCCCCCCC                       ffffffffffffffff    ffffffffffffffff     JJJJJJJJJJJ                                   kkkkkkkk           ");
            Console.WriteLine("     CCC::::::::::::C                      f::::::::::::::::f  f::::::::::::::::f    J:::::::::J                                   k::::::k           ");
            Console.WriteLine("   CC:::::::::::::::C                     f::::::::::::::::::ff::::::::::::::::::f   J:::::::::J                                   k::::::k           ");
            Console.WriteLine("  C:::::CCCCCCCC::::C                     f::::::fffffff:::::ff::::::fffffff:::::f   JJ:::::::JJ                                   k::::::k           ");
            Console.WriteLine(" C:::::C       CCCCCC    eeeeeeeeeeee     f:::::f       fffffff:::::f       ffffff     J:::::J  aaaaaaaaaaaaa      cccccccccccccccc k:::::k    kkkkkkk");
            Console.WriteLine("C:::::C                ee::::::::::::ee   f:::::f             f:::::f                  J:::::J  a::::::::::::a   cc:::::::::::::::c k:::::k   k:::::k ");
            Console.WriteLine("C:::::C               e::::::eeeee:::::eef:::::::ffffff      f:::::::ffffff            J:::::J  aaaaaaaaa:::::a c:::::::::::::::::c k:::::k  k:::::k  ");
            Console.WriteLine("C:::::C              e::::::e     e:::::ef::::::::::::f      f::::::::::::f            J:::::j           a::::ac:::::::cccccc:::::c k:::::k k:::::k   ");
            Console.WriteLine("C:::::C              e:::::::eeeee::::::ef::::::::::::f      f::::::::::::f            J:::::J    aaaaaaa:::::ac::::::c     ccccccc k::::::k:::::k    ");
            Console.WriteLine("C:::::C              e:::::::::::::::::e f:::::::ffffff      f:::::::ffffffJJJJJJJ     J:::::J  aa::::::::::::ac:::::c              k:::::::::::k     ");
            Console.WriteLine("C:::::C              e::::::eeeeeeeeeee   f:::::f             f:::::f      J:::::J     J:::::J a::::aaaa::::::ac:::::c              k:::::::::::k     ");
            Console.WriteLine(" C:::::C       CCCCCCe:::::::e            f:::::f             f:::::f      J::::::J   J::::::Ja::::a    a:::::ac::::::c     ccccccc k::::::k:::::k    ");
            Console.WriteLine("  C:::::CCCCCCCC::::Ce::::::::e          f:::::::f           f:::::::f     J:::::::JJJ:::::::Ja::::a    a:::::ac:::::::cccccc:::::ck::::::k k:::::k   ");
            Console.WriteLine("   CC:::::::::::::::C e::::::::eeeeeeee  f:::::::f           f:::::::f      JJ:::::::::::::JJ a:::::aaaa::::::a c:::::::::::::::::ck::::::k  k:::::k  ");
            Console.WriteLine("     CCC::::::::::::C  ee:::::::::::::e  f:::::::f           f:::::::f        JJ:::::::::JJ    a::::::::::aa:::a cc:::::::::::::::ck::::::k   k:::::k ");
            Console.WriteLine("        CCCCCCCCCCCCC    eeeeeeeeeeeeee  fffffffff           fffffffff          JJJJJJJJJ       aaaaaaaaaa  aaaa   cccccccccccccccckkkkkkkk    kkkkkkk");
            Console.WriteLine("\n\n\n");
        }

        public void DrawBet()
        {
            Console.WriteLine("///////////////////////////////////////////////////////");
            Console.WriteLine("///                                                 ///");
            Console.WriteLine("///           Nouveau Tour - A vos mises !          ///");
            Console.WriteLine("///                                                 ///");
            Console.WriteLine("///////////////////////////////////////////////////////");
        }

        public void DrawResults()
        {
            Console.WriteLine("///////////////////////////////////////////////////////");
            Console.WriteLine("///                                                 ///");
            Console.WriteLine("///           Résultats du tour - Qui a gagné ?     ///");
            Console.WriteLine("///                                                 ///");
            Console.WriteLine("///////////////////////////////////////////////////////");
            Console.WriteLine("\n\n\n");
        }

        public void DrawPlayersBalance()
        {
            Console.WriteLine("///////////////////////////////////////////////////////");
            Console.WriteLine("///                                                 ///");
            Console.WriteLine("///           Joueurs et leurs argents              ///");
            Console.WriteLine("///                                                 ///");
            Console.WriteLine("///////////////////////////////////////////////////////");
            Console.WriteLine("\n\n\n");
        }

        public void DrawFinishedGame()
        {
            Console.WriteLine("///////////////////////////////////////////////////////");
            Console.WriteLine("///                                                 ///");
            Console.WriteLine("///    Fin de la partie - Tout le monde à perdu !   ///");
            Console.WriteLine("///                                                 ///");
            Console.WriteLine("///////////////////////////////////////////////////////");
        }

        public void TurnBet(string name, int bet)
        {
            Console.WriteLine("///////////////////////////////////////////////////////\n");
            Console.WriteLine($"     Au tour de {name} - Avec une mise de {bet}$\n");
            Console.WriteLine("///////////////////////////////////////////////////////\n\n");
        }

        public void DrawBlackJack()
        {
            Console.WriteLine(" ,ggggggggggg,         ,gggg,            ,ggg,       ,gggg,   ,ggg,        gg  gg                ,ggg,       ,gggg,   ,ggg,        gg ");
            Console.WriteLine("dP\"\"\"88\"\"\"\"\"\"Y8,      d8\" \"8I           dP\"\"8I     ,88\"\"\"Y8b,dP\"\"Y8b       dP dP8,              dP\"\"8I     ,88\"\"\"Y8b,dP\"\"Y8b       dP ");
            Console.WriteLine("Yb,  88      `8b      88  ,dP          dP   88    d8\"     `Y8Yb, `88      d8'dP Yb             dP   88    d8\"     `Y8Yb, `88      d8' ");
            Console.WriteLine(" `\"  88      ,8P   8888888P\"          dP    88   d8'   8b  d8 `\"  88    ,dP',8  `8,           dP    88   d8'   8b  d8 `\"  88    ,dP'  ");
            Console.WriteLine("     88aaaad8P\"       88             ,8'    88  ,8I    \"Y88P'     88aaad8\"  I8   Yb          ,8'    88  ,8I    \"Y88P'     88aaad8\"    ");
            Console.WriteLine("     88\"\"\"\"Y8ba       88             d88888888  I8'               88\"\"\"\"Yb, `8b, `8,         d88888888  I8'               88\"\"\"\"Yb,   ");
            Console.WriteLine("\r     88\"\"\"\"Y8ba       88             d88888888  I8'               88\"\"\"\"Yb, `8b, `8,         d88888888  I8'               88\"\"\"\"Yb,   \r");
            Console.WriteLine("     88      `8b ,aa,_88       __   ,8\"     88  d8                88     \"8b `\"Y88888  __   ,8\"     88  d8                88     \"8b  ");
            Console.WriteLine("     88      ,8PdP\" \"88P      dP\"  ,8P      Y8  Y8,               88      `8i    \"Y8  dP\"  ,8P      Y8  Y8,               88      `8i ");
            Console.WriteLine("     88_____,d8'Yb,_,d88b,,_  Yb,_,dP       `8b,`Yba,,_____,      88       Yb,    ,88,Yb,_,dP       `8b,`Yba,,_____,      88       Yb,");
            Console.WriteLine("    88888888P\"   \"Y8P\"  \"Y88888\"Y8P\"         `Y8  `\"Y8888888      88        Y8,ad88888 \"Y8P\"         `Y8  `\"Y8888888      88        Y8");
            Console.WriteLine("                                                                            ,dP\"'   Yb                                                ");
            Console.WriteLine("                                                                           ,8'      I8                                                ");
            Console.WriteLine("                                                                          ,8'       I8                                                ");
            Console.WriteLine("                                                                         I8,      ,8'                                                ");
            Console.WriteLine("                                                                         `Y8,___,d8'                                                 ");
            Console.WriteLine("                                                                           \"Y888P\"                                                   ");
        }
    }
}
