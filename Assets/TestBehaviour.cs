using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Config;
using Unity.Mathematics;
using UnityEngine;

public class myClass
{
    public int field = 4;
}

[Serializable()]
public class TestBehaviour : MonoBehaviour
{
    public ComputeShader computeShader;
    public float[] matrixOut;
    public int testField = 1;
    private ComputeBuffer matrixABuffer;
    private ComputeBuffer matrixBBuffer;
    private ComputeBuffer matrixOutBuffer;

    private static readonly int matrixA_ID = Shader.PropertyToID("matrixA");
    private static readonly int matrixB_ID = Shader.PropertyToID("matrixB");
    private static readonly int matrixOut_ID = Shader.PropertyToID("matrixOut");
    private static readonly int size_ID = Shader.PropertyToID("_size");
    private static readonly int timeStamp_ID = Shader.PropertyToID("_dispatchTimeStamp");

    private void TestOfComputeShaderDoingRandom()
    {
        float[,] myMatrixA = new float[3, 3]{
            {1f, 2f, 3f},
            {2f, 0f, 4f},
            {3f, 6f, 1f},
        };
        float[,] myMatrixB = new float[3, 3]{
            {1f, 2f, 3f},
            {4f, 5f, 6f},
            {4f, 5f, 6f},
        };

        matrixABuffer = new ComputeBuffer(9, sizeof(float));
        matrixABuffer.SetData(myMatrixA);
        matrixBBuffer = new ComputeBuffer(9, sizeof(float));
        matrixBBuffer.SetData(myMatrixB);
        matrixOutBuffer = new ComputeBuffer(9, sizeof(float));
        
        int martixKernel = computeShader.FindKernel("CSMain");

        computeShader.SetInt(size_ID, 3);
        computeShader.SetInt(timeStamp_ID, (int)Time.time);
        computeShader.SetBuffer(martixKernel, matrixA_ID, matrixABuffer);
        computeShader.SetBuffer(martixKernel, matrixB_ID, matrixBBuffer);
        computeShader.SetBuffer(martixKernel, matrixOut_ID, matrixOutBuffer);

        computeShader.Dispatch(martixKernel, 1, 1, 1);
        matrixOut = new float[9];
        matrixOutBuffer.GetData(matrixOut);
        Debug.Log(matrixOut[0]);

        matrixABuffer.Release();
        matrixBBuffer.Release();
        matrixOutBuffer.Release();
    }

    
    public static void TestOfReflectionReadProperty()
    {
        var mt = MatterTable.Instance;
        mt.testFunc();
    }

    public static void TestOfReadTable()
    {
        var mt = MatterTable.Instance;
        Debug.Log(mt.getTableValue<string>("names", 4));
    }
    
    private void Start()
    {
        TestOfReadTable();
    }
}
