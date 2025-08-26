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
            var solutionBuffer = new double[50000];

            GridOc.gridoc_solve(
                collocationPoints, leftBoundaryPoints, rightBoundaryPoints,
                rMax, timeConstant, solutionBuffer, out var actualSize);
        
            var solution = new double[actualSize];
            Array.Copy(solutionBuffer, solution, actualSize);
        
            return solution;
        }
    }