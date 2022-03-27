
namespace OPD_konstantinov
{
    public class BubbleSort {

        public delegate bool Comparator(int a, int b);
        public static bool Ask(int a, int b) => a > b;
        public static bool Desc(int a, int b) => a < b;

        public delegate int Algorithm(ref int[,] matrix, int row);

        public static int SummaryRowSort(ref int[,] matrix, int row) {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(1); i++) {
                sum += matrix[row, i];
            }
            return sum;
        }

        public static int MaximumRowElementSort(ref int[,] matrix, int row) {
            int max = matrix[row, 0];
            for (int i = 1; i < matrix.GetLength(1); i++) {
                if(max < matrix[row, i]) {
                    max = matrix[row, i];
                }
            }
            return max;
        }

        public static int MinimumRowElementSort(ref int[,] matrix, int row) {
            int min = matrix[row, 0];
            for (int i = 1; i < matrix.GetLength(1); i++) {
                if (min > matrix[row, i]) {
                    min = matrix[row, i];
                }
            }
            return min;
        }

        private void SortWithCondition(ref (int, int)[] conditionMatrix, ref int[,] matrix, Comparator comparator) {
            (int, int) temp;
            for (int i = 0; i < conditionMatrix.GetLength(0); i++) {
                for (int j = 0; j < conditionMatrix.GetLength(0) - 1; j++) {
                    if (comparator(conditionMatrix[i].Item2, conditionMatrix[j].Item2)) {
                        RowSwap(ref matrix, conditionMatrix[i].Item1, conditionMatrix[j].Item1);
                        temp = conditionMatrix[i];
                        conditionMatrix[i] = conditionMatrix[j];
                        conditionMatrix[j] = temp;
                    }
                }
            }
        }
        
        private void RowSwap(ref int[,] matrix, int row1, int row2) {
            int temp = 0;
            for (int i = 0; i < matrix.GetLength(1); i++) {
                temp = matrix[row1, i];
                matrix[row1, i] = matrix[row2, i];
                matrix[row2, i] = temp;
            }
        }

        public void Sort(ref int[,] matrix, Algorithm algorithm, Comparator comparator) {
            (int, int)[] rowCompare = new (int, int)[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++) {
                rowCompare[i].Item1 = i;
                rowCompare[i].Item2 = algorithm(ref matrix, i);
            }
            SortWithCondition(ref rowCompare, ref matrix, comparator);
        }
    }

}
