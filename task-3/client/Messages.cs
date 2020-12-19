// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: messages.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from messages.proto</summary>
public static partial class MessagesReflection {

  #region Descriptor
  /// <summary>File descriptor for messages.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static MessagesReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "Cg5tZXNzYWdlcy5wcm90byI8CgZQZXJzb24SDwoHc3VybmFtZRgBIAEoCRIM",
          "CgRuYW1lGAIgASgJEhMKC3NlY29uZF9uYW1lGAMgASgJIjcKBFVuaXQSDAoE",
          "bmFtZRgBIAEoCRIOCgZnZW5kZXIYAiABKAgSEQoJdW5pdF90eXBlGAMgASgJ",
          "YgZwcm90bzM="));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { },
        new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::Person), global::Person.Parser, new[]{ "Surname", "Name", "SecondName" }, null, null, null, null),
          new pbr::GeneratedClrTypeInfo(typeof(global::Unit), global::Unit.Parser, new[]{ "Name", "Gender", "UnitType" }, null, null, null, null)
        }));
  }
  #endregion

}
#region Messages
public sealed partial class Person : pb::IMessage<Person>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<Person> _parser = new pb::MessageParser<Person>(() => new Person());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pb::MessageParser<Person> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::MessagesReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public Person() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public Person(Person other) : this() {
    surname_ = other.surname_;
    name_ = other.name_;
    secondName_ = other.secondName_;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public Person Clone() {
    return new Person(this);
  }

  /// <summary>Field number for the "surname" field.</summary>
  public const int SurnameFieldNumber = 1;
  private string surname_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Surname {
    get { return surname_; }
    set {
      surname_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "name" field.</summary>
  public const int NameFieldNumber = 2;
  private string name_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Name {
    get { return name_; }
    set {
      name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "second_name" field.</summary>
  public const int SecondNameFieldNumber = 3;
  private string secondName_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string SecondName {
    get { return secondName_; }
    set {
      secondName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override bool Equals(object other) {
    return Equals(other as Person);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Equals(Person other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Surname != other.Surname) return false;
    if (Name != other.Name) return false;
    if (SecondName != other.SecondName) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override int GetHashCode() {
    int hash = 1;
    if (Surname.Length != 0) hash ^= Surname.GetHashCode();
    if (Name.Length != 0) hash ^= Name.GetHashCode();
    if (SecondName.Length != 0) hash ^= SecondName.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void WriteTo(pb::CodedOutputStream output) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    output.WriteRawMessage(this);
  #else
    if (Surname.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Surname);
    }
    if (Name.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(Name);
    }
    if (SecondName.Length != 0) {
      output.WriteRawTag(26);
      output.WriteString(SecondName);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
    if (Surname.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Surname);
    }
    if (Name.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(Name);
    }
    if (SecondName.Length != 0) {
      output.WriteRawTag(26);
      output.WriteString(SecondName);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(ref output);
    }
  }
  #endif

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int CalculateSize() {
    int size = 0;
    if (Surname.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Surname);
    }
    if (Name.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
    }
    if (SecondName.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(SecondName);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(Person other) {
    if (other == null) {
      return;
    }
    if (other.Surname.Length != 0) {
      Surname = other.Surname;
    }
    if (other.Name.Length != 0) {
      Name = other.Name;
    }
    if (other.SecondName.Length != 0) {
      SecondName = other.SecondName;
    }
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(pb::CodedInputStream input) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    input.ReadRawMessage(this);
  #else
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 10: {
          Surname = input.ReadString();
          break;
        }
        case 18: {
          Name = input.ReadString();
          break;
        }
        case 26: {
          SecondName = input.ReadString();
          break;
        }
      }
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
          break;
        case 10: {
          Surname = input.ReadString();
          break;
        }
        case 18: {
          Name = input.ReadString();
          break;
        }
        case 26: {
          SecondName = input.ReadString();
          break;
        }
      }
    }
  }
  #endif

}

public sealed partial class Unit : pb::IMessage<Unit>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<Unit> _parser = new pb::MessageParser<Unit>(() => new Unit());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pb::MessageParser<Unit> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::MessagesReflection.Descriptor.MessageTypes[1]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public Unit() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public Unit(Unit other) : this() {
    name_ = other.name_;
    gender_ = other.gender_;
    unitType_ = other.unitType_;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public Unit Clone() {
    return new Unit(this);
  }

  /// <summary>Field number for the "name" field.</summary>
  public const int NameFieldNumber = 1;
  private string name_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Name {
    get { return name_; }
    set {
      name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "gender" field.</summary>
  public const int GenderFieldNumber = 2;
  private bool gender_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Gender {
    get { return gender_; }
    set {
      gender_ = value;
    }
  }

  /// <summary>Field number for the "unit_type" field.</summary>
  public const int UnitTypeFieldNumber = 3;
  private string unitType_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string UnitType {
    get { return unitType_; }
    set {
      unitType_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override bool Equals(object other) {
    return Equals(other as Unit);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Equals(Unit other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Name != other.Name) return false;
    if (Gender != other.Gender) return false;
    if (UnitType != other.UnitType) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override int GetHashCode() {
    int hash = 1;
    if (Name.Length != 0) hash ^= Name.GetHashCode();
    if (Gender != false) hash ^= Gender.GetHashCode();
    if (UnitType.Length != 0) hash ^= UnitType.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void WriteTo(pb::CodedOutputStream output) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    output.WriteRawMessage(this);
  #else
    if (Name.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Name);
    }
    if (Gender != false) {
      output.WriteRawTag(16);
      output.WriteBool(Gender);
    }
    if (UnitType.Length != 0) {
      output.WriteRawTag(26);
      output.WriteString(UnitType);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
    if (Name.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Name);
    }
    if (Gender != false) {
      output.WriteRawTag(16);
      output.WriteBool(Gender);
    }
    if (UnitType.Length != 0) {
      output.WriteRawTag(26);
      output.WriteString(UnitType);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(ref output);
    }
  }
  #endif

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int CalculateSize() {
    int size = 0;
    if (Name.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
    }
    if (Gender != false) {
      size += 1 + 1;
    }
    if (UnitType.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(UnitType);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(Unit other) {
    if (other == null) {
      return;
    }
    if (other.Name.Length != 0) {
      Name = other.Name;
    }
    if (other.Gender != false) {
      Gender = other.Gender;
    }
    if (other.UnitType.Length != 0) {
      UnitType = other.UnitType;
    }
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(pb::CodedInputStream input) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    input.ReadRawMessage(this);
  #else
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 10: {
          Name = input.ReadString();
          break;
        }
        case 16: {
          Gender = input.ReadBool();
          break;
        }
        case 26: {
          UnitType = input.ReadString();
          break;
        }
      }
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
          break;
        case 10: {
          Name = input.ReadString();
          break;
        }
        case 16: {
          Gender = input.ReadBool();
          break;
        }
        case 26: {
          UnitType = input.ReadString();
          break;
        }
      }
    }
  }
  #endif

}

#endregion


#endregion Designer generated code