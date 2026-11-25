using Input;
using Weapon;
using Zenject;

namespace Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputService>()
                .To<InputReader>()
                .FromComponentInHierarchy()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<WeaponController>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}