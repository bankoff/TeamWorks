using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITournament.CSharpCode.FactoryMethod
{
    public abstract class Theme: ICreatable
    {
        private string backgrounColour;
        private string fontColour;

        public string BackgrounColour
        {
            get { return backgrounColour; }
            set { backgrounColour = value; }
        }
        
        public string FontColour
        {
            get { return fontColour; }
            set { fontColour = value; }
        }

        protected Theme(string backgrounColour, string fontColour)
        {
            this.BackgrounColour = backgrounColour;
            this.FontColour = fontColour;
        }

        public abstract void Create();
    }
}
