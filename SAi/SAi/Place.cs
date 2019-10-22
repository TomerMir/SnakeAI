using System;
using System.Collections.Generic;
using System.Text;

namespace SAi
{
    public class Place
    {
        public enum WhatsInEnum {Boarder, Snake, Nothing, Food}
        public WhatsInEnum whatsIn;
        public int X;
        public int Y;
    }

}
