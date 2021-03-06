// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace ProximaX.Sirius.Chain.Sdk.Buffers
{

using global::System;
using global::FlatBuffers;

public struct CosignatoryModificationBuffer : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static CosignatoryModificationBuffer GetRootAsCosignatoryModificationBuffer(ByteBuffer _bb) { return GetRootAsCosignatoryModificationBuffer(_bb, new CosignatoryModificationBuffer()); }
  public static CosignatoryModificationBuffer GetRootAsCosignatoryModificationBuffer(ByteBuffer _bb, CosignatoryModificationBuffer obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public CosignatoryModificationBuffer __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public byte Type { get { int o = __p.__offset(4); return o != 0 ? __p.bb.Get(o + __p.bb_pos) : (byte)0; } }
  public byte CosignatoryPublicKey(int j) { int o = __p.__offset(6); return o != 0 ? __p.bb.Get(__p.__vector(o) + j * 1) : (byte)0; }
  public int CosignatoryPublicKeyLength { get { int o = __p.__offset(6); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetCosignatoryPublicKeyBytes() { return __p.__vector_as_span(6); }
#else
  public ArraySegment<byte>? GetCosignatoryPublicKeyBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetCosignatoryPublicKeyArray() { return __p.__vector_as_array<byte>(6); }

  public static Offset<CosignatoryModificationBuffer> CreateCosignatoryModificationBuffer(FlatBufferBuilder builder,
      byte type = 0,
      VectorOffset cosignatoryPublicKeyOffset = default(VectorOffset)) {
    builder.StartObject(2);
    CosignatoryModificationBuffer.AddCosignatoryPublicKey(builder, cosignatoryPublicKeyOffset);
    CosignatoryModificationBuffer.AddType(builder, type);
    return CosignatoryModificationBuffer.EndCosignatoryModificationBuffer(builder);
  }

  public static void StartCosignatoryModificationBuffer(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddType(FlatBufferBuilder builder, byte type) { builder.AddByte(0, type, 0); }
  public static void AddCosignatoryPublicKey(FlatBufferBuilder builder, VectorOffset cosignatoryPublicKeyOffset) { builder.AddOffset(1, cosignatoryPublicKeyOffset.Value, 0); }
  public static VectorOffset CreateCosignatoryPublicKeyVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateCosignatoryPublicKeyVectorBlock(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); builder.Add(data); return builder.EndVector(); }
  public static void StartCosignatoryPublicKeyVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  public static Offset<CosignatoryModificationBuffer> EndCosignatoryModificationBuffer(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<CosignatoryModificationBuffer>(o);
  }
};


}
