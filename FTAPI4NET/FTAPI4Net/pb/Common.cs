// Generated by ProtoGen, Version=2.4.1.555, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48.  DO NOT EDIT!
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.ProtocolBuffers;
using pbc = global::Google.ProtocolBuffers.Collections;
using pbd = global::Google.ProtocolBuffers.Descriptors;
using scg = global::System.Collections.Generic;
namespace Futu.OpenApi.Pb {
  
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  public static partial class Common {
  
    #region Extension registration
    public static void RegisterAllExtensions(pb::ExtensionRegistry registry) {
    }
    #endregion
    #region Static variables
    private static pbd::MessageDescriptor internal__static_Common_PacketID__Descriptor;
    private static pb::FieldAccess.FieldAccessorTable<global::Futu.OpenApi.Pb.Common.PacketID, global::Futu.OpenApi.Pb.Common.PacketID.Builder> internal__static_Common_PacketID__FieldAccessorTable;
    private static pbd::MessageDescriptor internal__static_Common_ProgramStatus__Descriptor;
    private static pb::FieldAccess.FieldAccessorTable<global::Futu.OpenApi.Pb.Common.ProgramStatus, global::Futu.OpenApi.Pb.Common.ProgramStatus.Builder> internal__static_Common_ProgramStatus__FieldAccessorTable;
    #endregion
    #region Descriptor
    public static pbd::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbd::FileDescriptor descriptor;
    
    static Common() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgxDb21tb24ucHJvdG8SBkNvbW1vbiI+CghQYWNrZXRJRBIWCgZjb25uSUQY", 
            "ASACKARSBmNvbm5JRBIaCghzZXJpYWxObxgCIAIoDVIIc2VyaWFsTm8iXgoN", 
            "UHJvZ3JhbVN0YXR1cxItCgR0eXBlGAEgAigOMhkuQ29tbW9uLlByb2dyYW1T", 
            "dGF0dXNUeXBlUgR0eXBlEh4KCnN0ckV4dERlc2MYAiABKAlSCnN0ckV4dERl", 
            "c2MqtgEKB1JldFR5cGUSEwoPUmV0VHlwZV9TdWNjZWVkEAASGwoOUmV0VHlw", 
            "ZV9GYWlsZWQQ////////////ARIcCg9SZXRUeXBlX1RpbWVPdXQQnP//////", 
            "////ARIfChJSZXRUeXBlX0Rpc0Nvbm5lY3QQuP7/////////ARIcCg9SZXRU", 
            "eXBlX1Vua25vd24Q8Pz/////////ARIcCg9SZXRUeXBlX0ludmFsaWQQjPz/", 
            "////////ASqDAQoNUGFja2V0RW5jQWxnbxIbChdQYWNrZXRFbmNBbGdvX0ZU", 
            "QUVTX0VDQhAAEh8KElBhY2tldEVuY0FsZ29fTm9uZRD///////////8BEhkK", 
            "FVBhY2tldEVuY0FsZ29fQUVTX0VDQhABEhkKFVBhY2tldEVuY0FsZ29fQUVT", 
            "X0NCQxACKjQKCFByb3RvRm10EhUKEVByb3RvRm10X1Byb3RvYnVmEAASEQoN", 
            "UHJvdG9GbXRfSnNvbhABKl4KD1VzZXJBdHRyaWJ1dGlvbhIbChdVc2VyQXR0", 
            "cmlidXRpb25fVW5rbm93bhAAEhYKElVzZXJBdHRyaWJ1dGlvbl9OThABEhYK", 
            "ElVzZXJBdHRyaWJ1dGlvbl9NTRACKvADChFQcm9ncmFtU3RhdHVzVHlwZRIa", 
            "ChZQcm9ncmFtU3RhdHVzVHlwZV9Ob25lEAASHAoYUHJvZ3JhbVN0YXR1c1R5", 
            "cGVfTG9hZGVkEAESHAoYUHJvZ3JhbVN0YXR1c1R5cGVfTG9naW5nEAISJwoj", 
            "UHJvZ3JhbVN0YXR1c1R5cGVfTmVlZFBpY1ZlcmlmeUNvZGUQAxIpCiVQcm9n", 
            "cmFtU3RhdHVzVHlwZV9OZWVkUGhvbmVWZXJpZnlDb2RlEAQSIQodUHJvZ3Jh", 
            "bVN0YXR1c1R5cGVfTG9naW5GYWlsZWQQBRIhCh1Qcm9ncmFtU3RhdHVzVHlw", 
            "ZV9Gb3JjZVVwZGF0ZRAGEioKJlByb2dyYW1TdGF0dXNUeXBlX05lc3NhcnlE", 
            "YXRhUHJlcGFyaW5nEAcSKAokUHJvZ3JhbVN0YXR1c1R5cGVfTmVzc2FyeURh", 
            "dGFNaXNzaW5nEAgSJwojUHJvZ3JhbVN0YXR1c1R5cGVfVW5BZ3JlZURpc2Ns", 
            "YWltZXIQCRIbChdQcm9ncmFtU3RhdHVzVHlwZV9SZWFkeRAKEiEKHVByb2dy", 
            "YW1TdGF0dXNUeXBlX0ZvcmNlTG9nb3V0EAsSKgomUHJvZ3JhbVN0YXR1c1R5", 
            "cGVfRGlzY2xhaW1lclB1bGxGYWlsZWQQDEI9ChNjb20uZnV0dS5vcGVuYXBp", 
          "LnBiWiZnaXRodWIuY29tL2Z1dHVvcGVuL2Z0YXBpNGdvL3BiL2NvbW1vbg=="));
      pbd::FileDescriptor.InternalDescriptorAssigner assigner = delegate(pbd::FileDescriptor root) {
        descriptor = root;
        internal__static_Common_PacketID__Descriptor = Descriptor.MessageTypes[0];
        internal__static_Common_PacketID__FieldAccessorTable = 
            new pb::FieldAccess.FieldAccessorTable<global::Futu.OpenApi.Pb.Common.PacketID, global::Futu.OpenApi.Pb.Common.PacketID.Builder>(internal__static_Common_PacketID__Descriptor,
                new string[] { "ConnID", "SerialNo", });
        internal__static_Common_ProgramStatus__Descriptor = Descriptor.MessageTypes[1];
        internal__static_Common_ProgramStatus__FieldAccessorTable = 
            new pb::FieldAccess.FieldAccessorTable<global::Futu.OpenApi.Pb.Common.ProgramStatus, global::Futu.OpenApi.Pb.Common.ProgramStatus.Builder>(internal__static_Common_ProgramStatus__Descriptor,
                new string[] { "Type", "StrExtDesc", });
        pb::ExtensionRegistry registry = pb::ExtensionRegistry.CreateInstance();
        RegisterAllExtensions(registry);
        return registry;
      };
      pbd::FileDescriptor.InternalBuildGeneratedFileFrom(descriptorData,
          new pbd::FileDescriptor[] {
          }, assigner);
    }
    #endregion
    
    #region Enums
    public enum RetType {
      RetType_Succeed = 0,
      RetType_Failed = -1,
      RetType_TimeOut = -100,
      RetType_DisConnect = -200,
      RetType_Unknown = -400,
      RetType_Invalid = -500,
    }
    
    public enum PacketEncAlgo {
      PacketEncAlgo_FTAES_ECB = 0,
      PacketEncAlgo_None = -1,
      PacketEncAlgo_AES_ECB = 1,
      PacketEncAlgo_AES_CBC = 2,
    }
    
    public enum ProtoFmt {
      ProtoFmt_Protobuf = 0,
      ProtoFmt_Json = 1,
    }
    
    public enum UserAttribution {
      UserAttribution_Unknown = 0,
      UserAttribution_NN = 1,
      UserAttribution_MM = 2,
    }
    
    public enum ProgramStatusType {
      ProgramStatusType_None = 0,
      ProgramStatusType_Loaded = 1,
      ProgramStatusType_Loging = 2,
      ProgramStatusType_NeedPicVerifyCode = 3,
      ProgramStatusType_NeedPhoneVerifyCode = 4,
      ProgramStatusType_LoginFailed = 5,
      ProgramStatusType_ForceUpdate = 6,
      ProgramStatusType_NessaryDataPreparing = 7,
      ProgramStatusType_NessaryDataMissing = 8,
      ProgramStatusType_UnAgreeDisclaimer = 9,
      ProgramStatusType_Ready = 10,
      ProgramStatusType_ForceLogout = 11,
      ProgramStatusType_DisclaimerPullFailed = 12,
    }
    
    #endregion
    
    #region Messages
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public sealed partial class PacketID : pb::GeneratedMessage<PacketID, PacketID.Builder> {
      private PacketID() { }
      private static readonly PacketID defaultInstance = new PacketID().MakeReadOnly();
      private static readonly string[] _packetIDFieldNames = new string[] { "connID", "serialNo" };
      private static readonly uint[] _packetIDFieldTags = new uint[] { 8, 16 };
      public static PacketID DefaultInstance {
        get { return defaultInstance; }
      }
      
      public override PacketID DefaultInstanceForType {
        get { return DefaultInstance; }
      }
      
      protected override PacketID ThisMessage {
        get { return this; }
      }
      
      public static pbd::MessageDescriptor Descriptor {
        get { return global::Futu.OpenApi.Pb.Common.internal__static_Common_PacketID__Descriptor; }
      }
      
      protected override pb::FieldAccess.FieldAccessorTable<PacketID, PacketID.Builder> InternalFieldAccessors {
        get { return global::Futu.OpenApi.Pb.Common.internal__static_Common_PacketID__FieldAccessorTable; }
      }
      
      public const int ConnIDFieldNumber = 1;
      private bool hasConnID;
      private ulong connID_;
      public bool HasConnID {
        get { return hasConnID; }
      }
      [global::System.CLSCompliant(false)]
      public ulong ConnID {
        get { return connID_; }
      }
      
      public const int SerialNoFieldNumber = 2;
      private bool hasSerialNo;
      private uint serialNo_;
      public bool HasSerialNo {
        get { return hasSerialNo; }
      }
      [global::System.CLSCompliant(false)]
      public uint SerialNo {
        get { return serialNo_; }
      }
      
      public override bool IsInitialized {
        get {
          if (!hasConnID) return false;
          if (!hasSerialNo) return false;
          return true;
        }
      }
      
      public override void WriteTo(pb::ICodedOutputStream output) {
        CalcSerializedSize();
        string[] field_names = _packetIDFieldNames;
        if (hasConnID) {
          output.WriteUInt64(1, field_names[0], ConnID);
        }
        if (hasSerialNo) {
          output.WriteUInt32(2, field_names[1], SerialNo);
        }
        UnknownFields.WriteTo(output);
      }
      
      private int memoizedSerializedSize = -1;
      public override int SerializedSize {
        get {
          int size = memoizedSerializedSize;
          if (size != -1) return size;
          return CalcSerializedSize();
        }
      }
      
      private int CalcSerializedSize() {
        int size = memoizedSerializedSize;
        if (size != -1) return size;
        
        size = 0;
        if (hasConnID) {
          size += pb::CodedOutputStream.ComputeUInt64Size(1, ConnID);
        }
        if (hasSerialNo) {
          size += pb::CodedOutputStream.ComputeUInt32Size(2, SerialNo);
        }
        size += UnknownFields.SerializedSize;
        memoizedSerializedSize = size;
        return size;
      }
      public static PacketID ParseFrom(pb::ByteString data) {
        return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
      }
      public static PacketID ParseFrom(pb::ByteString data, pb::ExtensionRegistry extensionRegistry) {
        return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
      }
      public static PacketID ParseFrom(byte[] data) {
        return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
      }
      public static PacketID ParseFrom(byte[] data, pb::ExtensionRegistry extensionRegistry) {
        return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
      }
      public static PacketID ParseFrom(global::System.IO.Stream input) {
        return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
      }
      public static PacketID ParseFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
        return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
      }
      public static PacketID ParseDelimitedFrom(global::System.IO.Stream input) {
        return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
      }
      public static PacketID ParseDelimitedFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
        return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
      }
      public static PacketID ParseFrom(pb::ICodedInputStream input) {
        return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
      }
      public static PacketID ParseFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry) {
        return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
      }
      private PacketID MakeReadOnly() {
        return this;
      }
      
      public static Builder CreateBuilder() { return new Builder(); }
      public override Builder ToBuilder() { return CreateBuilder(this); }
      public override Builder CreateBuilderForType() { return new Builder(); }
      public static Builder CreateBuilder(PacketID prototype) {
        return new Builder(prototype);
      }
      
      [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
      public sealed partial class Builder : pb::GeneratedBuilder<PacketID, Builder> {
        protected override Builder ThisBuilder {
          get { return this; }
        }
        public Builder() {
          result = DefaultInstance;
          resultIsReadOnly = true;
        }
        internal Builder(PacketID cloneFrom) {
          result = cloneFrom;
          resultIsReadOnly = true;
        }
        
        private bool resultIsReadOnly;
        private PacketID result;
        
        private PacketID PrepareBuilder() {
          if (resultIsReadOnly) {
            PacketID original = result;
            result = new PacketID();
            resultIsReadOnly = false;
            MergeFrom(original);
          }
          return result;
        }
        
        public override bool IsInitialized {
          get { return result.IsInitialized; }
        }
        
        protected override PacketID MessageBeingBuilt {
          get { return PrepareBuilder(); }
        }
        
        public override Builder Clear() {
          result = DefaultInstance;
          resultIsReadOnly = true;
          return this;
        }
        
        public override Builder Clone() {
          if (resultIsReadOnly) {
            return new Builder(result);
          } else {
            return new Builder().MergeFrom(result);
          }
        }
        
        public override pbd::MessageDescriptor DescriptorForType {
          get { return global::Futu.OpenApi.Pb.Common.PacketID.Descriptor; }
        }
        
        public override PacketID DefaultInstanceForType {
          get { return global::Futu.OpenApi.Pb.Common.PacketID.DefaultInstance; }
        }
        
        public override PacketID BuildPartial() {
          if (resultIsReadOnly) {
            return result;
          }
          resultIsReadOnly = true;
          return result.MakeReadOnly();
        }
        
        public override Builder MergeFrom(pb::IMessage other) {
          if (other is PacketID) {
            return MergeFrom((PacketID) other);
          } else {
            base.MergeFrom(other);
            return this;
          }
        }
        
        public override Builder MergeFrom(PacketID other) {
          if (other == global::Futu.OpenApi.Pb.Common.PacketID.DefaultInstance) return this;
          PrepareBuilder();
          if (other.HasConnID) {
            ConnID = other.ConnID;
          }
          if (other.HasSerialNo) {
            SerialNo = other.SerialNo;
          }
          this.MergeUnknownFields(other.UnknownFields);
          return this;
        }
        
        public override Builder MergeFrom(pb::ICodedInputStream input) {
          return MergeFrom(input, pb::ExtensionRegistry.Empty);
        }
        
        public override Builder MergeFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry) {
          PrepareBuilder();
          pb::UnknownFieldSet.Builder unknownFields = null;
          uint tag;
          string field_name;
          while (input.ReadTag(out tag, out field_name)) {
            if(tag == 0 && field_name != null) {
              int field_ordinal = global::System.Array.BinarySearch(_packetIDFieldNames, field_name, global::System.StringComparer.Ordinal);
              if(field_ordinal >= 0)
                tag = _packetIDFieldTags[field_ordinal];
              else {
                if (unknownFields == null) {
                  unknownFields = pb::UnknownFieldSet.CreateBuilder(this.UnknownFields);
                }
                ParseUnknownField(input, unknownFields, extensionRegistry, tag, field_name);
                continue;
              }
            }
            switch (tag) {
              case 0: {
                throw pb::InvalidProtocolBufferException.InvalidTag();
              }
              default: {
                if (pb::WireFormat.IsEndGroupTag(tag)) {
                  if (unknownFields != null) {
                    this.UnknownFields = unknownFields.Build();
                  }
                  return this;
                }
                if (unknownFields == null) {
                  unknownFields = pb::UnknownFieldSet.CreateBuilder(this.UnknownFields);
                }
                ParseUnknownField(input, unknownFields, extensionRegistry, tag, field_name);
                break;
              }
              case 8: {
                result.hasConnID = input.ReadUInt64(ref result.connID_);
                break;
              }
              case 16: {
                result.hasSerialNo = input.ReadUInt32(ref result.serialNo_);
                break;
              }
            }
          }
          
          if (unknownFields != null) {
            this.UnknownFields = unknownFields.Build();
          }
          return this;
        }
        
        
        public bool HasConnID {
          get { return result.hasConnID; }
        }
        [global::System.CLSCompliant(false)]
        public ulong ConnID {
          get { return result.ConnID; }
          set { SetConnID(value); }
        }
        [global::System.CLSCompliant(false)]
        public Builder SetConnID(ulong value) {
          PrepareBuilder();
          result.hasConnID = true;
          result.connID_ = value;
          return this;
        }
        public Builder ClearConnID() {
          PrepareBuilder();
          result.hasConnID = false;
          result.connID_ = 0UL;
          return this;
        }
        
        public bool HasSerialNo {
          get { return result.hasSerialNo; }
        }
        [global::System.CLSCompliant(false)]
        public uint SerialNo {
          get { return result.SerialNo; }
          set { SetSerialNo(value); }
        }
        [global::System.CLSCompliant(false)]
        public Builder SetSerialNo(uint value) {
          PrepareBuilder();
          result.hasSerialNo = true;
          result.serialNo_ = value;
          return this;
        }
        public Builder ClearSerialNo() {
          PrepareBuilder();
          result.hasSerialNo = false;
          result.serialNo_ = 0;
          return this;
        }
      }
      static PacketID() {
        object.ReferenceEquals(global::Futu.OpenApi.Pb.Common.Descriptor, null);
      }
    }
    
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public sealed partial class ProgramStatus : pb::GeneratedMessage<ProgramStatus, ProgramStatus.Builder> {
      private ProgramStatus() { }
      private static readonly ProgramStatus defaultInstance = new ProgramStatus().MakeReadOnly();
      private static readonly string[] _programStatusFieldNames = new string[] { "strExtDesc", "type" };
      private static readonly uint[] _programStatusFieldTags = new uint[] { 18, 8 };
      public static ProgramStatus DefaultInstance {
        get { return defaultInstance; }
      }
      
      public override ProgramStatus DefaultInstanceForType {
        get { return DefaultInstance; }
      }
      
      protected override ProgramStatus ThisMessage {
        get { return this; }
      }
      
      public static pbd::MessageDescriptor Descriptor {
        get { return global::Futu.OpenApi.Pb.Common.internal__static_Common_ProgramStatus__Descriptor; }
      }
      
      protected override pb::FieldAccess.FieldAccessorTable<ProgramStatus, ProgramStatus.Builder> InternalFieldAccessors {
        get { return global::Futu.OpenApi.Pb.Common.internal__static_Common_ProgramStatus__FieldAccessorTable; }
      }
      
      public const int TypeFieldNumber = 1;
      private bool hasType;
      private global::Futu.OpenApi.Pb.Common.ProgramStatusType type_ = global::Futu.OpenApi.Pb.Common.ProgramStatusType.ProgramStatusType_None;
      public bool HasType {
        get { return hasType; }
      }
      public global::Futu.OpenApi.Pb.Common.ProgramStatusType Type {
        get { return type_; }
      }
      
      public const int StrExtDescFieldNumber = 2;
      private bool hasStrExtDesc;
      private string strExtDesc_ = "";
      public bool HasStrExtDesc {
        get { return hasStrExtDesc; }
      }
      public string StrExtDesc {
        get { return strExtDesc_; }
      }
      
      public override bool IsInitialized {
        get {
          if (!hasType) return false;
          return true;
        }
      }
      
      public override void WriteTo(pb::ICodedOutputStream output) {
        CalcSerializedSize();
        string[] field_names = _programStatusFieldNames;
        if (hasType) {
          output.WriteEnum(1, field_names[1], (int) Type, Type);
        }
        if (hasStrExtDesc) {
          output.WriteString(2, field_names[0], StrExtDesc);
        }
        UnknownFields.WriteTo(output);
      }
      
      private int memoizedSerializedSize = -1;
      public override int SerializedSize {
        get {
          int size = memoizedSerializedSize;
          if (size != -1) return size;
          return CalcSerializedSize();
        }
      }
      
      private int CalcSerializedSize() {
        int size = memoizedSerializedSize;
        if (size != -1) return size;
        
        size = 0;
        if (hasType) {
          size += pb::CodedOutputStream.ComputeEnumSize(1, (int) Type);
        }
        if (hasStrExtDesc) {
          size += pb::CodedOutputStream.ComputeStringSize(2, StrExtDesc);
        }
        size += UnknownFields.SerializedSize;
        memoizedSerializedSize = size;
        return size;
      }
      public static ProgramStatus ParseFrom(pb::ByteString data) {
        return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
      }
      public static ProgramStatus ParseFrom(pb::ByteString data, pb::ExtensionRegistry extensionRegistry) {
        return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
      }
      public static ProgramStatus ParseFrom(byte[] data) {
        return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
      }
      public static ProgramStatus ParseFrom(byte[] data, pb::ExtensionRegistry extensionRegistry) {
        return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
      }
      public static ProgramStatus ParseFrom(global::System.IO.Stream input) {
        return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
      }
      public static ProgramStatus ParseFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
        return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
      }
      public static ProgramStatus ParseDelimitedFrom(global::System.IO.Stream input) {
        return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
      }
      public static ProgramStatus ParseDelimitedFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
        return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
      }
      public static ProgramStatus ParseFrom(pb::ICodedInputStream input) {
        return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
      }
      public static ProgramStatus ParseFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry) {
        return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
      }
      private ProgramStatus MakeReadOnly() {
        return this;
      }
      
      public static Builder CreateBuilder() { return new Builder(); }
      public override Builder ToBuilder() { return CreateBuilder(this); }
      public override Builder CreateBuilderForType() { return new Builder(); }
      public static Builder CreateBuilder(ProgramStatus prototype) {
        return new Builder(prototype);
      }
      
      [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
      public sealed partial class Builder : pb::GeneratedBuilder<ProgramStatus, Builder> {
        protected override Builder ThisBuilder {
          get { return this; }
        }
        public Builder() {
          result = DefaultInstance;
          resultIsReadOnly = true;
        }
        internal Builder(ProgramStatus cloneFrom) {
          result = cloneFrom;
          resultIsReadOnly = true;
        }
        
        private bool resultIsReadOnly;
        private ProgramStatus result;
        
        private ProgramStatus PrepareBuilder() {
          if (resultIsReadOnly) {
            ProgramStatus original = result;
            result = new ProgramStatus();
            resultIsReadOnly = false;
            MergeFrom(original);
          }
          return result;
        }
        
        public override bool IsInitialized {
          get { return result.IsInitialized; }
        }
        
        protected override ProgramStatus MessageBeingBuilt {
          get { return PrepareBuilder(); }
        }
        
        public override Builder Clear() {
          result = DefaultInstance;
          resultIsReadOnly = true;
          return this;
        }
        
        public override Builder Clone() {
          if (resultIsReadOnly) {
            return new Builder(result);
          } else {
            return new Builder().MergeFrom(result);
          }
        }
        
        public override pbd::MessageDescriptor DescriptorForType {
          get { return global::Futu.OpenApi.Pb.Common.ProgramStatus.Descriptor; }
        }
        
        public override ProgramStatus DefaultInstanceForType {
          get { return global::Futu.OpenApi.Pb.Common.ProgramStatus.DefaultInstance; }
        }
        
        public override ProgramStatus BuildPartial() {
          if (resultIsReadOnly) {
            return result;
          }
          resultIsReadOnly = true;
          return result.MakeReadOnly();
        }
        
        public override Builder MergeFrom(pb::IMessage other) {
          if (other is ProgramStatus) {
            return MergeFrom((ProgramStatus) other);
          } else {
            base.MergeFrom(other);
            return this;
          }
        }
        
        public override Builder MergeFrom(ProgramStatus other) {
          if (other == global::Futu.OpenApi.Pb.Common.ProgramStatus.DefaultInstance) return this;
          PrepareBuilder();
          if (other.HasType) {
            Type = other.Type;
          }
          if (other.HasStrExtDesc) {
            StrExtDesc = other.StrExtDesc;
          }
          this.MergeUnknownFields(other.UnknownFields);
          return this;
        }
        
        public override Builder MergeFrom(pb::ICodedInputStream input) {
          return MergeFrom(input, pb::ExtensionRegistry.Empty);
        }
        
        public override Builder MergeFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry) {
          PrepareBuilder();
          pb::UnknownFieldSet.Builder unknownFields = null;
          uint tag;
          string field_name;
          while (input.ReadTag(out tag, out field_name)) {
            if(tag == 0 && field_name != null) {
              int field_ordinal = global::System.Array.BinarySearch(_programStatusFieldNames, field_name, global::System.StringComparer.Ordinal);
              if(field_ordinal >= 0)
                tag = _programStatusFieldTags[field_ordinal];
              else {
                if (unknownFields == null) {
                  unknownFields = pb::UnknownFieldSet.CreateBuilder(this.UnknownFields);
                }
                ParseUnknownField(input, unknownFields, extensionRegistry, tag, field_name);
                continue;
              }
            }
            switch (tag) {
              case 0: {
                throw pb::InvalidProtocolBufferException.InvalidTag();
              }
              default: {
                if (pb::WireFormat.IsEndGroupTag(tag)) {
                  if (unknownFields != null) {
                    this.UnknownFields = unknownFields.Build();
                  }
                  return this;
                }
                if (unknownFields == null) {
                  unknownFields = pb::UnknownFieldSet.CreateBuilder(this.UnknownFields);
                }
                ParseUnknownField(input, unknownFields, extensionRegistry, tag, field_name);
                break;
              }
              case 8: {
                object unknown;
                if(input.ReadEnum(ref result.type_, out unknown)) {
                  result.hasType = true;
                } else if(unknown is int) {
                  if (unknownFields == null) {
                    unknownFields = pb::UnknownFieldSet.CreateBuilder(this.UnknownFields);
                  }
                  unknownFields.MergeVarintField(1, (ulong)(int)unknown);
                }
                break;
              }
              case 18: {
                result.hasStrExtDesc = input.ReadString(ref result.strExtDesc_);
                break;
              }
            }
          }
          
          if (unknownFields != null) {
            this.UnknownFields = unknownFields.Build();
          }
          return this;
        }
        
        
        public bool HasType {
         get { return result.hasType; }
        }
        public global::Futu.OpenApi.Pb.Common.ProgramStatusType Type {
          get { return result.Type; }
          set { SetType(value); }
        }
        public Builder SetType(global::Futu.OpenApi.Pb.Common.ProgramStatusType value) {
          PrepareBuilder();
          result.hasType = true;
          result.type_ = value;
          return this;
        }
        public Builder ClearType() {
          PrepareBuilder();
          result.hasType = false;
          result.type_ = global::Futu.OpenApi.Pb.Common.ProgramStatusType.ProgramStatusType_None;
          return this;
        }
        
        public bool HasStrExtDesc {
          get { return result.hasStrExtDesc; }
        }
        public string StrExtDesc {
          get { return result.StrExtDesc; }
          set { SetStrExtDesc(value); }
        }
        public Builder SetStrExtDesc(string value) {
          pb::ThrowHelper.ThrowIfNull(value, "value");
          PrepareBuilder();
          result.hasStrExtDesc = true;
          result.strExtDesc_ = value;
          return this;
        }
        public Builder ClearStrExtDesc() {
          PrepareBuilder();
          result.hasStrExtDesc = false;
          result.strExtDesc_ = "";
          return this;
        }
      }
      static ProgramStatus() {
        object.ReferenceEquals(global::Futu.OpenApi.Pb.Common.Descriptor, null);
      }
    }
    
    #endregion
    
  }
}

#endregion Designer generated code
