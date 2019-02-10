using System;
using System.Collections.Generic;

namespace RBoggleAPI.Boards
{
    public interface IBoard
    {
        List<String> Solve();
    }
}
