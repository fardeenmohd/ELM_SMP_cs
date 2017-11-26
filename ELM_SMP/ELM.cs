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
        Matrix<double> IW;
        Matrix<double> Betha;
        Matrix<double> H;

        Matrix<double> X;
        Matrix<double> Y;
        //actfun (1./(1+exp(-x))) //logistic function its called in this library //or i can (tanh+1)/2
        int bias;

        public ELM(int nInputs,int nHidden,int bias,Matrix<double> data)
        {
            this.nInputs = nInputs;
            this.nHidden = nHidden;
            this.bias = bias;
            Matrix<double>[] XY= rearrangingData6feat(data);
            this.X =XY[0];
            this.Y = XY[1];

        }

        public void train(Matrix<double> X, Matrix<double> Y)
        {
            // X.append tutaj
//            X = [(ones(size(X, 1), 1) * obj.bias) X];
//            obj.IW = randInitializeWeights(obj.nInputs, obj.nHidden);
//            obj.H = X * obj.IW';
//obj.Betha = pinv(obj.H) * Y;
        }
        public void predict(Matrix<double> X)
        {
            //X = [(ones(size(X, 1), 1) * obj.bias) X];
            //Hi = X * obj.IW';
            //Y = Hi * obj.Betha;
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
            int nrows=Xra.;
            // this 3 lines wont be needed later need to change them
            //Matrix<double> Xflipped = Matrix<double>.Build.DenseOfRowArrays(Xra);
            //int ncols = Xflipped.ColumnCount;
            //int nrows = Xflipped.RowCount;
            //double[][] fin =new double[nrows/6][];
            //double[][] finy = new double[nrows / 6][];
            //for (int i = 0; i < nrows; i=+6)
            //{
            //    for (int j = 0; j < 30; j++)
            //    {
            //        if (j <= 5)
            //            fin[i][j] = Xra[i][j];
            //        else if (j<=11)
            //            fin[i][j] = Xra[i+1][j-6];
            //        else if (j <= 17)
            //            fin[i][j] = Xra[i + 2][j - 12];
            //        else if (j <= 23)
            //            fin[i][j] = Xra[i + 3][j - 18];
            //        else if (j <= 29)
            //            fin[i][j] = Xra[i + 4][j - 24];

            //    }
            //    finy[i] = Xra[i + 5];
            //}

           // XY[0] = Matrix<double>.Build.DenseOfRowArrays(fin);
           // XY[1] = Matrix<double>.Build.DenseOfRowArrays(finy);

            return XY;
        }

    }


    //public static t[][] tojaggedarray<t>(this t[,] twodimensionalarray)
    //{
    //    int rowsfirstindex = twodimensionalarray.getlowerbound(0);
    //    int rowslastindex = twodimensionalarray.getupperbound(0);
    //    int numberofrows = rowslastindex + 1;

    //    int columnsfirstindex = twodimensionalarray.getlowerbound(1);
    //    int columnslastindex = twodimensionalarray.getupperbound(1);
    //    int numberofcolumns = columnslastindex + 1;

    //    t[][] jaggedarray = new t[numberofrows][];
    //    for (int i = rowsfirstindex; i <= rowslastindex; i++)
    //    {
    //        jaggedarray[i] = new t[numberofcolumns];

    //        for (int j = columnsfirstindex; j <= columnslastindex; j++)
    //        {
    //            jaggedarray[i][j] = twodimensionalarray[i, j];
    //        }
    //    }
    //    return jaggedarray;
    //}
}
