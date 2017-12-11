using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace ELM_SMP
{
    class ELM
    {
        int nInputs;
        int nHidden;
        int nOutputs;
        int nFeatures;
        int bias;
        int trainProportion;

        Matrix<double> IW;
        Matrix<double> Betha;
        Matrix<double> H;
        Matrix<double> X;
        Matrix<double> Y;
        public Matrix<double> Xtrain,Xtest,Ytrain,Ytest;
        //actfun (1./(1+exp(-x))) //logistic function its called in this library //or i can (tanh+1)/2
        

        public ELM(int nInputs,int nHidden,int nOutputs,int bias,Matrix<double> data, int trainProportion)
        {
            this.nInputs = nInputs;
            this.nHidden = nHidden;
            this.nOutputs = nOutputs;
            this.bias = bias;
            this.trainProportion = trainProportion;
            //data = data.SubMatrix(0, data.RowCount, 1, 4);
            this.nFeatures = data.ColumnCount;
            Matrix<double>[] XY= rearrangingData6feat(data);
            Matrix<double>[] XY1 = rearrangeData(data);
            this.X =XY[0];
            this.Y = XY[1];
            Matrix<double>[] ret = setProportionsOfData( X, Y, trainProportion);
            this.Xtrain = ret[0];
            this.Ytrain = ret[1];
            this.Xtest = ret[2];
            this.Ytest = ret[3];

        }


        /// <summary>
        /// Returns array of matrices where element at index 0 is Xtrain,at 1 Ytrain, at 2 Xtest at  3 Ytest
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="perc"></param>
        /// <returns></returns>
        public Matrix<double>[] setProportionsOfData( Matrix<double>  X, Matrix<double>  Y, int perc)
        {
            if (perc < 15)
                perc = 20;
            if (perc > 95)
                perc = 90;
            // Matrix<double> Xtrain = Matrix<double>.Build.Dense(X.RowCount, X.ColumnCount, X.ToColumnMajorArray());
            // Matrix<double> Xtrain = Matrix<double>.Build.DenseOfMatrix(X);
            int trainingSize = (perc * X.RowCount) / 100;
            Matrix<double> Xtrain = X.SubMatrix(0, trainingSize, 0, X.ColumnCount);
            Matrix<double> Xtest = X.SubMatrix(trainingSize, X.RowCount-trainingSize, 0, X.ColumnCount);
            Matrix<double> Ytrain = Y.SubMatrix(0, trainingSize, 0, Y.ColumnCount);
            Matrix<double> Ytest = Y.SubMatrix(trainingSize, Y.RowCount - trainingSize, 0, Y.ColumnCount);

            Matrix<double>[] XtrYtrXtYt = new Matrix<double>[4];

            XtrYtrXtYt[0] = Xtrain;
            XtrYtrXtYt[1] = Ytrain;
            XtrYtrXtYt[2] = Xtest;
            XtrYtrXtYt[3] = Ytest;
            return XtrYtrXtYt;

        }
        public void train(Matrix<double> Xtrainset, Matrix<double> Ytrainset)
        {
            Matrix<double> biasM = Matrix<double>.Build.Dense(Xtrainset.RowCount, 1, (i, j) => 1*this.bias);
            Xtrainset = biasM.Append(Xtrainset);
            double epsilon_init = 0.12;
            IW = Matrix<double>.Build.Random(nHidden, nInputs + 1).Multiply(2 * epsilon_init).Add(-epsilon_init);
            this.H = Xtrainset.Multiply(IW.Transpose());
            this.Betha = H.PseudoInverse().Multiply(Ytrainset);
        }
        public Matrix<double> predict(Matrix<double> Xtest)
        {
            Matrix<double> biasM = Matrix<double>.Build.Dense(Xtest.RowCount, 1, (i, j) => 1 * this.bias);
            Xtest = biasM.Append(Xtest);
            Matrix<double> Hi = Xtest.Multiply(this.IW.Transpose());
            Matrix<double> Y = Hi.Multiply(this.Betha);
            return Y;
        }

        public Matrix<double>[] rearrangeData(Matrix<double> X)
        {
            Matrix<double>[] XY = new Matrix<double>[2];
            
            
            int rc = X.RowCount;
            int cc = X.ColumnCount;
            int sizeOfRearrangedData = rc - (nInputs + nOutputs) + 1;

            Matrix<double> XT = X.Transpose();

            int j = 0;

            for (int i = 0; i < sizeOfRearrangedData; i++)
            {
                          
                

            }
            

            return XY;

        }

        public Matrix<double>[] rearrangingData6feat(Matrix<double> X)
        {
                   
            Matrix<double>[] XY = new Matrix<double>[2];
            int rc = X.RowCount;
 
            int todelete = rc % 6;
            if (todelete != 0)
                for(int i =0;i<todelete;i++)
                X=X.RemoveRow(X.RowCount-1);
            //X = X.PointwiseTanh().Add(1).Divide(2); // should be the same as sigmoid
             double[][] Xra = X.ToRowArrays();
           // double[,] Xra = X.ToArray();
            Array.Reverse(Xra);
            
            int nrows=Xra.Count();
            double[][] fin = new double[nrows / 6][];
            double[][] finy = new double[nrows / 6][];
            for(int k=0;k<nrows/6;k++)
            {
                fin[k] = new double[30];
                finy[k] = new double[6];

            }

            for (int i = 0; i < nrows; i = i+6)
            {
                for (int j = 0; j < 30; j++)
                {

               
                        if (j <= 5)
                            fin[i/6][j] = Xra[i][j];
                        else if (j <= 11)
                            fin[i/6][j] = Xra[i + 1][j - 6];
                        else if (j <= 17)
                            fin[i/6][j] = Xra[i + 2][j - 12];
                        else if (j <= 23)
                            fin[i/6][j] = Xra[i + 3][j - 18];
                        else if (j <= 29)
                            fin[i/6][j] = Xra[i + 4][j - 24];
                    
                    

                    
                }
                finy[i/6] = Xra[i + 5];
            }

            XY[0] = Matrix<double>.Build.DenseOfRowArrays(fin);
            XY[1] = Matrix<double>.Build.DenseOfRowArrays(finy);

          
            return XY;
        }

    }

    
}
