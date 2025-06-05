using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Children)] // ⚠️ Enables parallel scenario execution within each feature
[assembly: LevelOfParallelism(2)] // Adjust based on CPU cores