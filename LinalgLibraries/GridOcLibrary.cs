using System;

namespace LinalgLibraries;

public static class GridOcLibrary
    {
        public static double[] Solve(
            uint collocationPoints = 50,
            uint leftBoundaryPoints = 1,
            uint rightBoundaryPoints = 1,
            double rMax = 0.0,
            double timeConstant = 1.0)
        {
            // since max collocation points is 200 before numerical instability,
            // 202 * 202 = 40840 and 50000 is a safe estimate for solution buffer size
            double[] solutionBuffer = new double[50000];
            int actualSize;
        
            try
            {
                GridOc.gridoc_solve(
                    collocationPoints, leftBoundaryPoints, rightBoundaryPoints,
                    rMax, timeConstant, solutionBuffer, out actualSize);
            }
            catch (DllNotFoundException)
            {
                throw new InvalidOperationException("Could not find C++ library");
            }
        
            double[] solution = new double[actualSize];
            Array.Copy(solutionBuffer, solution, actualSize);
        
            return solution;
        }
    }