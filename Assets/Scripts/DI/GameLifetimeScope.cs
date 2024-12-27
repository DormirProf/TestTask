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
        [SerializeField]  private CellsLoader _cellsLoader;
        [SerializeField]  private CellAnimationActivator _cellAnimationActivator;
        [SerializeField]  private TextFadeEffect _textFadeEffect;
        [SerializeField]  private UsedFindIdentifiers _usedFindIdentifiers;
        [SerializeField]  private GridColumnsSizeUpdater _gridColumnsSizeUpdater;
        [SerializeField]  private FindText _findText;
        
        protected override void Configure(IContainerBuilder builder)
        {
           builder.RegisterComponent(_levelTransition);
           builder.RegisterComponent(_findText);
           builder.RegisterComponent(_gridColumnsSizeUpdater);
           builder.RegisterComponent(_cellsLoader);
           builder.RegisterComponent(_cellAnimationActivator);
           builder.RegisterComponent(_textFadeEffect);
           builder.RegisterComponent(_usedFindIdentifiers);
        }
    }
}