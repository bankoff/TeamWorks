using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITournament;

namespace UITournament.CSharpCode.FactoryMethod
{
    public class MakeBlueTheme : Make
    {
        public override Theme MakeTheme()
        {
            //Theme(string backgrounColour, string fontColour)
            Theme theme = new BlueTheme("Orange", "Black");
             
            return theme;
        }
    }
}
