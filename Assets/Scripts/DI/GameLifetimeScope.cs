using Scripts.Animations;
using Scripts.Cell;
using Scripts.Level;
using Scripts.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scripts.DI
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField]  private LevelTransition _levelTransition;
        [SerializeField]  private TextFadeEffect _textFadeEffect;
        [SerializeField]  private GridColumnsSizeUpdater _gridColumnsSizeUpdater;
        [SerializeField]  private FindText _findText;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<CellGenerator>(Lifetime.Singleton);
            builder.Register<RandomFindIdentifier>(Lifetime.Singleton);
            builder.Register<UsedFindIdentifiers>(Lifetime.Singleton);
            builder.Register<LevelCreator>(Lifetime.Singleton);
            builder.Register<CellPool>(Lifetime.Singleton);
            builder.Register<CellAnimationActivator>(Lifetime.Singleton);
            builder.Register<CellSelector>(Lifetime.Singleton);
            builder.RegisterComponent(_levelTransition);
            builder.RegisterComponent(_findText);
            builder.RegisterComponent(_gridColumnsSizeUpdater);
            builder.RegisterComponent(_textFadeEffect);
        }
    }
}