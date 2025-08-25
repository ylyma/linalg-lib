using System.Runtime.InteropServices;

namespace LinalgLibraries;

public static class GridOc
{
    private const string LibraryName = "gridoc.dll";
    
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void gridoc_solve(
        uint collocation_points,
        uint left_boundary_points,
        uint right_boundary_points,
        double r_max,
        double time_constant,
        [Out] double[] solution_out,
        out int solution_size_out
    );
}