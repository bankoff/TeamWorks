using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITournament.CSharpCode.FactoryMethod
{
    public class DarkTheme:Theme
    {
        public DarkTheme(string backgrounColour, string fontColour)
            : base(backgrounColour,fontColour)
        {
        }

        public override void Create()
        {
        }
    }
}
