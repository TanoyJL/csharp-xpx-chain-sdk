// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace ProximaX.Sirius.Chain.Sdk.Buffers
{

using global::System;
using global::FlatBuffers;

public struct ModifyMetadataTransactionBuffer : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static ModifyMetadataTransactionBuffer GetRootAsModifyMetadataTransactionBuffer(ByteBuffer _bb) { return GetRootAsModifyMetadataTransactionBuffer(_bb, new ModifyMetadataTransactionBuffer()); }
  public static ModifyMetadataTransactionBuffer GetRootAsModifyMetadataTransactionBuffer(ByteBuffer _bb, ModifyMetadataTransactionBuffer obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public ModifyMetadataTransactionBuffer __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint Size { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public byte Signature(int j) { int o = __p.__offset(6); return o != 0 ? __p.bb.Get(__p.__vector(o) + j * 1) : (byte)0; }
  public int SignatureLength { get { int o = __p.__offset(6); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetSignatureBytes() { return __p.__vector_as_span(6); }
#else
  public ArraySegment<byte>? GetSignatureBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetSignatureArray() { return __p.__vector_as_array<byte>(6); }
  public byte Signer(int j) { int o = __p.__offset(8); return o != 0 ? __p.bb.Get(__p.__vector(o) + j * 1) : (byte)0; }
  public int SignerLength { get { int o = __p.__offset(8); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetSignerBytes() { return __p.__vector_as_span(8); }
#else
  public ArraySegment<byte>? GetSignerBytes() { return __p.__vector_as_arraysegment(8); }
#endif
  public byte[] GetSignerArray() { return __p.__vector_as_array<byte>(8); }
  public uint Version { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public ushort Type { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetUshort(o + __p.bb_pos) : (ushort)0; } }
  public uint MaxFee(int j) { int o = __p.__offset(14); return o != 0 ? __p.bb.GetUint(__p.__vector(o) + j * 4) : (uint)0; }
  public int MaxFeeLength { get { int o = __p.__offset(14); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetMaxFeeBytes() { return __p.__vector_as_span(14); }
#else
  public ArraySegment<byte>? GetMaxFeeBytes() { return __p.__vector_as_arraysegment(14); }
#endif
  public uint[] GetMaxFeeArray() { return __p.__vector_as_array<uint>(14); }
  public uint Deadline(int j) { int o = __p.__offset(16); return o != 0 ? __p.bb.GetUint(__p.__vector(o) + j * 4) : (uint)0; }
  public int DeadlineLength { get { int o = __p.__offset(16); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetDeadlineBytes() { return __p.__vector_as_span(16); }
#else
  public ArraySegment<byte>? GetDeadlineBytes() { return __p.__vector_as_arraysegment(16); }
#endif
  public uint[] GetDeadlineArray() { return __p.__vector_as_array<uint>(16); }
  public byte MetadataType { get { int o = __p.__offset(18); return o != 0 ? __p.bb.Get(o + __p.bb_pos) : (byte)0; } }
  /// In case of address it is 25 bytes array. In case of mosaic or namespace it is 8 byte array(or 2 uint32 array)
  public byte MetadataId(int j) { int o = __p.__offset(20); return o != 0 ? __p.bb.Get(__p.__vector(o) + j * 1) : (byte)0; }
  public int MetadataIdLength { get { int o = __p.__offset(20); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetMetadataIdBytes() { return __p.__vector_as_span(20); }
#else
  public ArraySegment<byte>? GetMetadataIdBytes() { return __p.__vector_as_arraysegment(20); }
#endif
  public byte[] GetMetadataIdArray() { return __p.__vector_as_array<byte>(20); }
  public MetadataModificationBuffer? Modifications(int j) { int o = __p.__offset(22); return o != 0 ? (MetadataModificationBuffer?)(new MetadataModificationBuffer()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int ModificationsLength { get { int o = __p.__offset(22); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<ModifyMetadataTransactionBuffer> CreateModifyMetadataTransactionBuffer(FlatBufferBuilder builder,
      uint size = 0,
      VectorOffset signatureOffset = default(VectorOffset),
      VectorOffset signerOffset = default(VectorOffset),
      uint version = 0,
      ushort type = 0,
      VectorOffset maxFeeOffset = default(VectorOffset),
      VectorOffset deadlineOffset = default(VectorOffset),
      byte metadataType = 0,
      VectorOffset metadataIdOffset = default(VectorOffset),
      VectorOffset modificationsOffset = default(VectorOffset)) {
    builder.StartObject(10);
    ModifyMetadataTransactionBuffer.AddModifications(builder, modificationsOffset);
    ModifyMetadataTransactionBuffer.AddMetadataId(builder, metadataIdOffset);
    ModifyMetadataTransactionBuffer.AddDeadline(builder, deadlineOffset);
    ModifyMetadataTransactionBuffer.AddMaxFee(builder, maxFeeOffset);
    ModifyMetadataTransactionBuffer.AddVersion(builder, version);
    ModifyMetadataTransactionBuffer.AddSigner(builder, signerOffset);
    ModifyMetadataTransactionBuffer.AddSignature(builder, signatureOffset);
    ModifyMetadataTransactionBuffer.AddSize(builder, size);
    ModifyMetadataTransactionBuffer.AddType(builder, type);
    ModifyMetadataTransactionBuffer.AddMetadataType(builder, metadataType);
    return ModifyMetadataTransactionBuffer.EndModifyMetadataTransactionBuffer(builder);
  }

  public static void StartModifyMetadataTransactionBuffer(FlatBufferBuilder builder) { builder.StartObject(10); }
  public static void AddSize(FlatBufferBuilder builder, uint size) { builder.AddUint(0, size, 0); }
  public static void AddSignature(FlatBufferBuilder builder, VectorOffset signatureOffset) { builder.AddOffset(1, signatureOffset.Value, 0); }
  public static VectorOffset CreateSignatureVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateSignatureVectorBlock(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); builder.Add(data); return builder.EndVector(); }
  public static void StartSignatureVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  public static void AddSigner(FlatBufferBuilder builder, VectorOffset signerOffset) { builder.AddOffset(2, signerOffset.Value, 0); }
  public static VectorOffset CreateSignerVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateSignerVectorBlock(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); builder.Add(data); return builder.EndVector(); }
  public static void StartSignerVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  public static void AddVersion(FlatBufferBuilder builder, uint version) { builder.AddUint(3, version, 0); }
  public static void AddType(FlatBufferBuilder builder, ushort type) { builder.AddUshort(4, type, 0); }
  public static void AddMaxFee(FlatBufferBuilder builder, VectorOffset maxFeeOffset) { builder.AddOffset(5, maxFeeOffset.Value, 0); }
  public static VectorOffset CreateMaxFeeVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateMaxFeeVectorBlock(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartMaxFeeVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddDeadline(FlatBufferBuilder builder, VectorOffset deadlineOffset) { builder.AddOffset(6, deadlineOffset.Value, 0); }
  public static VectorOffset CreateDeadlineVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateDeadlineVectorBlock(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartDeadlineVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddMetadataType(FlatBufferBuilder builder, byte metadataType) { builder.AddByte(7, metadataType, 0); }
  public static void AddMetadataId(FlatBufferBuilder builder, VectorOffset metadataIdOffset) { builder.AddOffset(8, metadataIdOffset.Value, 0); }
  public static VectorOffset CreateMetadataIdVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateMetadataIdVectorBlock(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); builder.Add(data); return builder.EndVector(); }
  public static void StartMetadataIdVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  public static void AddModifications(FlatBufferBuilder builder, VectorOffset modificationsOffset) { builder.AddOffset(9, modificationsOffset.Value, 0); }
  public static VectorOffset CreateModificationsVector(FlatBufferBuilder builder, Offset<MetadataModificationBuffer>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateModificationsVectorBlock(FlatBufferBuilder builder, Offset<MetadataModificationBuffer>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartModificationsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<ModifyMetadataTransactionBuffer> EndModifyMetadataTransactionBuffer(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<ModifyMetadataTransactionBuffer>(o);
  }
  public static void FinishModifyMetadataTransactionBufferBuffer(FlatBufferBuilder builder, Offset<ModifyMetadataTransactionBuffer> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedModifyMetadataTransactionBufferBuffer(FlatBufferBuilder builder, Offset<ModifyMetadataTransactionBuffer> offset) { builder.FinishSizePrefixed(offset.Value); }
};


}
