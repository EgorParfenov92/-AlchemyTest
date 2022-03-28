using System;

interface IRoundUI
{
    bool Pause { get; set; }
    IElement MainElement { get; }
    event Action ElementReplaced;
    event Action RoundFail;
    event Action RoundWon;
    event Action Action;
}