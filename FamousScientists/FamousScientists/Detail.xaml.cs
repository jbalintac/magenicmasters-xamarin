using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FamousScientists
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Detail : ContentPage
	{
        public Dictionary<string, ScientistBio> BioList { get; set; }

		public Detail (string Name)
		{
			InitializeComponent ();

            BioList = new Dictionary<string, ScientistBio>
            {
                { "Sir Isaac Newton", new ScientistBio { Name = "Sir Isaac Newton", DPResource = "isaac_newton.jpg", Year = "1642 – 1726" , Description= "Newton was a polymath who made investigations into a whole range of subjects including mathematics, optics, physics, and astronomy. In his Principia Mathematica, published in 1687, he laid the foundations for classical mechanics, explaining the law of gravity and the laws of motion." } },
                { "Louis Pasteur", new ScientistBio { Name = "Louis Pasteur", DPResource = "louis_pasteur.jpg", Year = "1822–1895" , Description= "Pasteur contributed greatly towards the advancement of medical sciences developing cures for rabies, anthrax and other infectious diseases. Also invented the process of pasteurisation to make milk safer to drink. He probably saved more lives than any other person." } },
                { "Galileo", new ScientistBio { Name = "Galileo", DPResource = "galileo.jpg", Year = "1564 – 1642" , Description= "Creating one of the first modern telescopes, Galileo revolutionised our understanding of the world, successfully proving the Earth revolves around the Sun and not the other way around. His work Two New Sciences laid the groundwork for the science of Kinetics and strength of materials." } },
                { "Marie Curie", new ScientistBio { Name = "Marie Curie", DPResource = "marie_curie.jpg", Year = "1867 – 1934" , Description= "Polish physicist and chemist. Discovered radiation and helped to apply it in the field of X-ray. She won the Nobel Prize in both Chemistry and Physics." } },
                { "Albert Einstein", new ScientistBio { Name = "Albert Einstein", DPResource = "albert_einstein.jpg", Year = "1879 – 1955" , Description= "Revolutionised modern physics with his general theory of relativity. He won the Nobel Prize in Physics (1921) for his discovery of the Photoelectric effect, which formed the basis of Quantum Theory." } },
                { "Charles Darwin", new ScientistBio { Name = "Charles Darwin", DPResource = "charles_darwin.jpg", Year = "1809 – 1882" , Description= "Darwin developed his theory of evolution against a backdrop of disbelief and scepticism. He collected evidence over 20 years and published his conclusions in On the Origin of Species (1859)" } },
                { "Otto Hahn", new ScientistBio { Name = "Otto Hahn", DPResource = "otto_hahn.jpg", Year = "1879 – 1968" , Description= "Hahn was a German chemist who discovered nuclear fission (1939). He was a pioneering scientist in the field of radiochemistry and discovered radioactive elements and nuclear isomerism (1921). He was awarded the Nobel Prize for Chemistry in 1944." } },
                { "Nikola Tesla", new ScientistBio { Name = "Nikola Tesla", DPResource = "nikola_tesla.jpg", Year = "1856 – 1943" , Description= "Tesla worked on electromagnetism and AC current. He is credited with many patents from electricity to radio transmission and played a key role in the development of modern electricity." } },
                { "James Clerk Maxwell", new ScientistBio { Name = "James Clerk Maxwell", DPResource = "james_clerk_maxwell.jpg", Year = "1831 – 1879" , Description= "Maxwell made great strides in understanding electromagnetism. His research in electricity and kinetics laid the foundation for quantum physics. Einstein said of Maxwell, “The work of James Clerk Maxwell changed the world forever.”" } },
                { "Aristotle", new ScientistBio { Name = "Aristotle", DPResource = "aristotle.jpg", Year = "384 BCE – 322 BCE" , Description= " A great early Greek scientist who made many types of research in the natural sciences including botany, zoology, physics, astronomy, chemistry, meteorology and geometry." } },
            };

            this.Title = BioList[Name].Name;
            this.Year.Text = BioList[Name].Year;
            this.Bio.Text = BioList[Name].Description;
            this.DP.Source = BioList[Name].DPResource;

        }
	}

    public class ScientistBio
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public string DPResource { get; set; }
        public string Description { get; set; }
    }
}