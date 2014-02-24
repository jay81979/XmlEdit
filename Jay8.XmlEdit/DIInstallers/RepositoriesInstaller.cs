using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Jay8.XmlEdit.Models;

namespace Jay8.XmlEdit.DIInstallers
{
    public class RepositoriesInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IXmlRepository>().ImplementedBy<XmlRepository>().LifestylePerWebRequest());
        }
    }
}