using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace ELM_SMP
{
    /// <summary>
    /// Author: Fardin Mohammed
    /// Last Modified Date: 21.01.2018
    /// </summary>
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

        /// <summary>
        /// Constructor for the ELM Network 
        /// </summary>
        /// <param name="nInputs">Number of days to use in predictions</param>
        /// <param name="nHidden">Size of the hidden layer</param>
        /// <param name="nOutputs">Number of days we want to predict</param>
        /// <param name="bias">Bias value for each layer</param>
        /// <param name="data">Data from the file turned into a matrix</param>
        /// <param name="trainProportion"></param>
        public ELM(int nInputs,int nHidden,int nOutputs,int bias,Matrix<double> data, int trainProportion)
        {
            this.nInputs = nInputs;
            this.nHidden = nHidden;
            this.nOutputs = nOutputs;
            this.bias = bias;
            this.trainProportion = trainProportion;
            this.nFeatures = data.ColumnCount;
            Matrix<double>[] XY = rearrangeData(data);
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
        /// <summary>
        /// Trains the ELM
        /// </summary>
        /// <param name="Xtrainset"></param>
        /// <param name="Ytrainset"></param>
        public void train(Matrix<double> Xtrainset, Matrix<double> Ytrainset)
        {
            Matrix<double> biasM = Matrix<double>.Build.Dense(Xtrainset.RowCount, 1, (i, j) => 1*this.bias);
            Xtrainset = biasM.Append(Xtrainset);
            IW = Matrix<double>.Build.Random(nHidden, nInputs * this.nFeatures + 1);
            this.H = Xtrainset.Multiply(IW.Transpose());
            this.Betha = H.PseudoInverse().Multiply(Ytrainset);
        }
        /// <summary>
        /// Predicts using the ELM
        /// </summary>
        /// <param name="Xtest"></param>
        /// <returns></returns>
        public Matrix<double> predict(Matrix<double> Xtest)
        {
            Matrix<double> biasM = Matrix<double>.Build.Dense(Xtest.RowCount, 1, (i, j) => 1 * this.bias);
            Xtest = biasM.Append(Xtest);
            Matrix<double> Hi = Xtest.Multiply(this.IW.Transpose());
            Matrix<double> Y = Hi.Multiply(this.Betha);
            return Y;
        }

        /// <summary>
        /// Custom tailor the data for the ELM depending on how many days to use for how many days of prediction
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public Matrix<double>[] rearrangeData(Matrix<double> X)
        {
            Matrix<double>[] XY = new Matrix<double>[2];
            
            
            int rc = X.RowCount;
            int cc = X.ColumnCount;
            int sizeOfRearrangedData = rc - (nInputs + nOutputs) + 1;

            Matrix<double> XT = X.Transpose();

            int j = 0;

            double[] Xar = X.ToRowMajorArray();
            double[][] oX = new double[sizeOfRearrangedData][];
            double[][] oY = new double[sizeOfRearrangedData][];

            for (int k = 0; k < sizeOfRearrangedData; k++)
            {
                oX[k] = new double[this.nInputs*cc];
                oY[k] = new double[this.nOutputs*cc];

            }

            for (int i = 0; i < sizeOfRearrangedData ; i++)
            {
                double[] newXRow = new ArraySegment<double>(Xar, j, this.nInputs * cc).ToArray();
                double[] newYRow = new ArraySegment<double>(Xar, nInputs * cc + j, cc * this.nOutputs).ToArray();

                oX[i] = newXRow;
                oY[i] = newYRow;
                
                j = i * cc ;

            }

            XY[0] = Matrix<double>.Build.DenseOfRowArrays(oX);
            XY[1] = Matrix<double>.Build.DenseOfRowArrays(oY);

            return XY;

        }
        

    }

    
}
