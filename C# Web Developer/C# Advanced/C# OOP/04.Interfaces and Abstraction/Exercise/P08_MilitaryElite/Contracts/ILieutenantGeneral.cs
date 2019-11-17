namespace P08_MilitaryElite.Contracts
{
    using System.Collections.Generic;

    public interface ILieutenantGeneral
    {
        //--------- Properties ---------
        IReadOnlyCollection<IPrivate> Privates { get; }

        //---------- Methods -----------
        void AddPrivate(IPrivate @private);

    }
}
