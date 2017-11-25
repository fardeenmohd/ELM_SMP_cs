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
        //actfun (1./(1+exp(-x)))
        int bias;

        public ELM(int nInputs,int nHidden,int bias)
        {
            this.nInputs = nInputs;
            this.nHidden = nHidden;
            this.bias = bias;

        }

        public void train(Matrix<double> X, Matrix<double> Y)
        {
            //X =;
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
    }
}
