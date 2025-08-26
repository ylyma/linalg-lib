using System.Runtime.InteropServices;

namespace LinalgLibraries;

public static class GridOc
{
    private const string LibraryName = "gridoc.dll";
    
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void gridoc_solve(
        uint collocationPoints,
        uint leftBoundaryPoints,
        uint rightBoundaryPoints,
        double rMax,
        double timeConstant,
        [Out] double[] solutionOut,
        out int solutionSizeOut
    );
}