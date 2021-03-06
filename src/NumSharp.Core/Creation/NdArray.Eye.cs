﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NumSharp.Core
{
    public partial class NDArray
    {
        public NDArray eye(int dim, int diagonalIndex = 0)
        {
            int noOfDiagElement = dim - Math.Abs(diagonalIndex);

            NDArray puffer = null;

            if((ndim == 1) && (dim != 1))
            {
                puffer = new NDArray(this.dtype, dim,dim);
            }
            else 
            {
                puffer = new NDArray(this.dtype,this.shape.Shapes.ToArray());
            }
            
            puffer.Storage.SetData(Array.CreateInstance(dtype,puffer.size));

            Array storageArr = puffer.Storage.GetData();

            if (diagonalIndex > -1)
                for(int idx = 0; idx < noOfDiagElement;idx++ )
                    storageArr.SetValue(1,diagonalIndex + idx + idx * puffer.shape.Shapes[1]); 
            else 
                for(int idx = dim - 1; idx > dim - noOfDiagElement - 1;idx-- )
                    storageArr.SetValue(1,diagonalIndex + idx + idx * puffer.shape.Shapes[1]); // = 1;

            this.Storage = puffer.Storage;
            
            return puffer;
        }
    }
}
