#include "pch-cpp.hpp"





template <typename T1>
struct VirtualActionInvoker1
{
	typedef void (*Action)(void*,T1,const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj,p1,invokeData.method);
	}
};
template <typename R>
struct VirtualFuncInvoker0
{
	typedef R (*Func)(void*,const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj,invokeData.method);
	}
};
template <typename R, typename T1>
struct VirtualFuncInvoker1
{
	typedef R (*Func)(void*,T1,const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj,p1,invokeData.method);
	}
};
template <typename R, typename T1, typename T2>
struct VirtualFuncInvoker2
{
	typedef R (*Func)(void*,T1,T2,const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj,p1,p2,invokeData.method);
	}
};
template <typename T1>
struct InvokerActionInvoker1;
template <typename T1>
struct InvokerActionInvoker1<T1*>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1)
	{
		void* params[1] = { p1 };
		method->invoker_method(methodPtr, method, obj, params, params[0]);
	}
};

struct CacheDict_2_t3592A9BE3B1E812BCE8A13D901156E74C707DBB7;
struct CacheDict_2_tB695739D50653F4D4C3DA03BCF07CC868196FB15;
struct ConditionalWeakTable_2_t0F3FDA57EE333DF8B8C1F3FB944E4E19C5DDCFC7;
struct Dictionary_2_tEF46B4EA472A35123947A8DF4F68C3E8A5F0C4FD;
struct DynamicArray_1_tE5A650707ED617C8B11E4B6F29F3207E02383467;
struct DynamicArray_1_t2A75BEDB4D41FF2FB6EC822B2CFBD037211F784D;
struct DynamicArray_1_tFD6392EE4EAA442D167A921C9964FD9C17FDCDE0;
struct Expression_1_t0FC093B0DDEA1EB4F5EF3152CC33F1B785E80EA4;
struct HashSet_1_t068F5201D923072F46716204841D21328FE6218D;
struct HashSet_1_tBCF0302A9E9E74ECC464F4B0C6A09F22E5114AFD;
struct IEqualityComparer_1_t3950A1C72D0704C9A5D08F255CB6BE1525EDC4A9;
struct List_1_t4A27DCC9A4080D8DA642DEA4EFFEBA72D6471715;
struct ObjectPool_1_tF11864F05C33C2DB6AAE614D05951B55BB8BC340;
struct Property_2_tE9B27417C17E0D8EA0D6A88F71B3C9347F2332A3;
struct Stack_1_tC4810ACEE7FD00840B5CB4333A83E2E1553CAD26;
struct Stack_1_t0CA5713F7DD620D4C839FC6F19CEA972026B8212;
struct HashSet_1U5BU5D_tFCEF942AC56CEEEEF243A16089184E53958046D4;
struct SlotU5BU5D_t5B6221310D92CD3EFED99B5A41997E4715E36338;
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;
struct CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB;
struct IRenderGraphResourceU5BU5D_tF72B9471181CD494E8F4A0274F40A7A037FF44C7;
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C;
struct IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832;
struct PropertyPathPartU5BU5D_t7994D542F14DDDDEABB1792C335C20149399AEBB;
struct SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C;
struct StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF;
struct TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB;
struct __Il2CppFullySharedGenericTypeU5BU5D_tCAB6D060972DD49223A834B7EEFEB9FE2D003BEC;
struct Binder_t91BFCE95A7057FADF4D8A1A342AFE52872246235;
struct Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3;
struct Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785;
struct IDictionary_t6D03155AF1FA9083817AA5B6AD7DEEACC26AB220;
struct IProperty_t9DAAF3D1ACD042DA2D622152506F58CE625EF697;
struct IRenderGraphResource_t8C49F0158EDB9571FA4BDAF754E09A32E535C021;
struct IRenderGraphResourcePool_tBCC3743B6D9FE5AA6513FE6F643B1A51B7060D35;
struct IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82;
struct InterpretedFrame_tF030A9AC78837B1C2F9CD54B43F7A04D85A8D92D;
struct InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB;
struct LambdaExpression_tD26FB6AEAD01B2EBB668CDEAFAAFA4948697300E;
struct MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553;
struct ParameterExpression_tE8D3A1137422F75D256CBB200EDC82820F240110;
struct SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6;
struct SerializationInfo_t3C47F63E24BEB9FCE2DC6309E027F238DC5C5E37;
struct String_t;
struct Type_t;
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;
struct ReaderHandle_t7A818FF1A9ACF79E6D6322AFF494B9FB12C48CC8;
struct WriterHandle_tBDBA7A52860089574884E6269EF80A4ABDA26BE6;
struct GetPropertyVisitor_t88183F280884F26458B42DAF173F005F3625F540;
struct ExpressionQuoter_t3D5F35B2980800F7F947EBC0819D867CF5AAD536;
struct RenderGraphResourcesData_t4E1A864AD7A36EC74B28D89C86E3A4D0997958CF;
struct ResourceCallback_tAD2AFD87AC5F4806D2DE0A543648F1FA25E52356;
struct ResourceCreateCallback_t801515B956F3C21C25B4DD6A4E4E01BBCF12E657;

IL2CPP_EXTERN_C RuntimeClass* Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* HashSet_1_t068F5201D923072F46716204841D21328FE6218D_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Type_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral000D6B4454BE3C3F0EB965604C293E0C0FE8F28E;
IL2CPP_EXTERN_C String_t* _stringLiteral27C7727EAAAD675C621F6257F2BD5190CE343979;
IL2CPP_EXTERN_C String_t* _stringLiteral4EBC86E0EACFCA522AEB82874860D0E248D782A5;
IL2CPP_EXTERN_C String_t* _stringLiteral973C45718ACB19FB28D206360A3094F43D27EDED;
IL2CPP_EXTERN_C const RuntimeMethod* DynamicArray_1_Resize_m71330886D4896ECE91617DB09FAF262B0E24B00B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* GCHandle_get_Target_m481F9508DA5E384D33CD1F4450060DC56BBD4CD5_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* HashSet_1_Add_m9B1803FBD20D89F056AD75F1B6B0E1F5D5CF4F69_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* HashSet_1__ctor_mC6742D4B2D1A12A042DB56C25EEF951C4BAC992B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* PrimitivesConverters_TryConvertPrimitiveOrString_TisDouble_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m29A9863FEB29DD171534C86E92808796F4F4451A_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* PrimitivesConverters_TryConvertPrimitiveOrString_TisDouble_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m8FF415C41F9748700137EB247B2399BE6D3629AC_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Quaternion_get_Item_m0B886A8EF3417F3309FB0C681A67A4150B7AA739_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Quaternion_set_Item_mFEF628DD58AC71A1E712A6F3F9642D5DA00675CE_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Stack_1_Pop_mBE2B08F95D18382A9C64D99E1065B899EB75E6E5_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Stack_1_Push_m7705C6FDAFECD165E7E24091F066CB47F323E6CE_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector3_set_Item_m79136861DEC5862CE7EC20AB3B0EF10A3957CEC3_RuntimeMethod_var;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;
struct PropertyPathPart_tFB308743948D2298957DC1898D90AF2ACFED9DFF_marshaled_com;
struct PropertyPathPart_tFB308743948D2298957DC1898D90AF2ACFED9DFF_marshaled_pinvoke;

struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;
struct ParameterExpressionU5BU5D_tA217A6969CA4383EF6D3C43B8EB0989358ABE72C;
struct SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
struct DynamicArray_1_tE5A650707ED617C8B11E4B6F29F3207E02383467  : public RuntimeObject
{
	IRenderGraphResourceU5BU5D_tF72B9471181CD494E8F4A0274F40A7A037FF44C7* ___m_Array;
	int32_t ___U3CsizeU3Ek__BackingField;
};
struct DynamicArray_1_tFD6392EE4EAA442D167A921C9964FD9C17FDCDE0  : public RuntimeObject
{
	__Il2CppFullySharedGenericTypeU5BU5D_tCAB6D060972DD49223A834B7EEFEB9FE2D003BEC* ___m_Array;
	int32_t ___U3CsizeU3Ek__BackingField;
};
struct HashSet_1_t068F5201D923072F46716204841D21328FE6218D  : public RuntimeObject
{
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ____buckets;
	SlotU5BU5D_t5B6221310D92CD3EFED99B5A41997E4715E36338* ____slots;
	int32_t ____count;
	int32_t ____lastIndex;
	int32_t ____freeList;
	RuntimeObject* ____comparer;
	int32_t ____version;
	SerializationInfo_t3C47F63E24BEB9FCE2DC6309E027F238DC5C5E37* ____siInfo;
};
struct Property_2_tE9B27417C17E0D8EA0D6A88F71B3C9347F2332A3  : public RuntimeObject
{
	List_1_t4A27DCC9A4080D8DA642DEA4EFFEBA72D6471715* ___m_Attributes;
};
struct Stack_1_tC4810ACEE7FD00840B5CB4333A83E2E1553CAD26  : public RuntimeObject
{
	HashSet_1U5BU5D_tFCEF942AC56CEEEEF243A16089184E53958046D4* ____array;
	int32_t ____size;
	int32_t ____version;
	RuntimeObject* ____syncRoot;
};
struct Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785  : public RuntimeObject
{
};
struct ExpressionVisitor_tD26583FF464068F23017BC372C81133A62C5A590  : public RuntimeObject
{
};
struct IRenderGraphResource_t8C49F0158EDB9571FA4BDAF754E09A32E535C021  : public RuntimeObject
{
	bool ___imported;
	bool ___shared;
	bool ___sharedExplicitRelease;
	bool ___requestFallBack;
	uint32_t ___writeCount;
	uint32_t ___readCount;
	int32_t ___cachedHash;
	int32_t ___transientPassIndex;
	int32_t ___sharedResourceLastFrameUsed;
	bool ___isBackBuffer;
};
struct IRenderGraphResourcePool_tBCC3743B6D9FE5AA6513FE6F643B1A51B7060D35  : public RuntimeObject
{
	bool ___U3CIntraFrameMemoryAliasingU3Ek__BackingField;
};
struct MemberInfo_t  : public RuntimeObject
{
};
struct String_t  : public RuntimeObject
{
	int32_t ____stringLength;
	Il2CppChar ____firstChar;
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};
struct MarshalledUnityObject_tA225A4A0AE6E49830C3C0142B2984549E0786A28  : public RuntimeObject
{
};
struct RenderGraphResourcesData_t4E1A864AD7A36EC74B28D89C86E3A4D0997958CF  : public RuntimeObject
{
	DynamicArray_1_tE5A650707ED617C8B11E4B6F29F3207E02383467* ___resourceArray;
	int32_t ___sharedResourcesCount;
	IRenderGraphResourcePool_tBCC3743B6D9FE5AA6513FE6F643B1A51B7060D35* ___pool;
	ResourceCreateCallback_t801515B956F3C21C25B4DD6A4E4E01BBCF12E657* ___createResourceCallback;
	ResourceCallback_tAD2AFD87AC5F4806D2DE0A543648F1FA25E52356* ___releaseResourceCallback;
};
struct PrimitivesConverters_t4AC0AF040C8B4B0C9C0C9A0A6F806521CFD84F27  : public RuntimeObject
{
};
typedef Il2CppFullySharedGenericStruct BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10;
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	bool ___m_value;
};
struct Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3 
{
	uint8_t ___m_value;
};
struct Char_t521A6F19B456D956AF452D926C32709DC03D6B17 
{
	Il2CppChar ___m_value;
};
struct Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F 
{
	double ___m_value;
};
struct EntityId_t982FBD037EAC5CA077B1602A7EA40E3523AA0FC8 
{
	union
	{
		struct
		{
			uint64_t ___m_rawData;
		};
		uint8_t EntityId_t982FBD037EAC5CA077B1602A7EA40E3523AA0FC8__padding[8];
	};
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2  : public ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F
{
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_marshaled_pinvoke
{
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_marshaled_com
{
};
struct FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 
{
	ReaderHandle_t7A818FF1A9ACF79E6D6322AFF494B9FB12C48CC8* ___Handle;
};
struct FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC 
{
	WriterHandle_tBDBA7A52860089574884E6269EF80A4ABDA26BE6* ___Handle;
};
struct Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175 
{
	int16_t ___m_value;
};
struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	int32_t ___m_value;
};
struct Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3 
{
	int64_t ___m_value;
};
struct IntPtr_t 
{
	void* ___m_value;
};
struct LambdaExpression_tD26FB6AEAD01B2EBB668CDEAFAAFA4948697300E  : public Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785
{
	Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785* ____body;
};
struct ParameterExpression_tE8D3A1137422F75D256CBB200EDC82820F240110  : public Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785
{
	String_t* ___U3CNameU3Ek__BackingField;
};
struct PhysicsHandle_tEC3DCC38ABB8395068171070539ABF8309A854C2 
{
	int32_t ___m_Index1;
	uint16_t ___m_World0;
	uint16_t ___m_Generation;
};
struct Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 
{
	float ___x;
	float ___y;
	float ___z;
	float ___w;
};
struct SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5 
{
	int8_t ___m_value;
};
struct Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C 
{
	float ___m_value;
};
struct UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455 
{
	uint16_t ___m_value;
};
struct UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B 
{
	uint32_t ___m_value;
};
struct UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF 
{
	uint64_t ___m_value;
};
struct Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 
{
	float ___x;
	float ___y;
};
struct Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 
{
	float ___x;
	float ___y;
	float ___z;
};
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};
struct bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02 
{
	bool ___x;
	bool ___y;
	bool ___z;
};
struct float3_t7600B73F092B37F484B12910A5269F30C778D31E 
{
	float ___x;
	float ___y;
	float ___z;
};
struct float4_t545A994996126766890C1F28B43EA823F2410190 
{
	float ___x;
	float ___y;
	float ___z;
	float ___w;
};
struct half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 
{
	uint16_t ___value;
};
struct ForEnums_tD6A048FB8E80A3A6DC7DE4B6DE48D635362F7511 
{
	union
	{
		struct
		{
		};
		uint8_t ForEnums_tD6A048FB8E80A3A6DC7DE4B6DE48D635362F7511__padding[1];
	};
};
struct ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 
{
	union
	{
		struct
		{
		};
		uint8_t ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3__padding[1];
	};
};
struct ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 
{
	union
	{
		struct
		{
		};
		uint8_t ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292__padding[1];
	};
};
struct AnimationState_t90091AD2757C132602279750EFF7907F066817B0 
{
	bool ___HasBeenProcessed;
	int32_t ___StateHash;
	float ___NormalizedTime;
	int32_t ___Layer;
	float ___Weight;
	float ___Duration;
	bool ___Transition;
	bool ___CrossFade;
	uint8_t ___m_StateFlags;
	int32_t ___DestinationStateHash;
};
struct AnimationState_t90091AD2757C132602279750EFF7907F066817B0_marshaled_pinvoke
{
	int32_t ___HasBeenProcessed;
	int32_t ___StateHash;
	float ___NormalizedTime;
	int32_t ___Layer;
	float ___Weight;
	float ___Duration;
	int32_t ___Transition;
	int32_t ___CrossFade;
	uint8_t ___m_StateFlags;
	int32_t ___DestinationStateHash;
};
struct AnimationState_t90091AD2757C132602279750EFF7907F066817B0_marshaled_com
{
	int32_t ___HasBeenProcessed;
	int32_t ___StateHash;
	float ___NormalizedTime;
	int32_t ___Layer;
	float ___Weight;
	float ___Duration;
	int32_t ___Transition;
	int32_t ___CrossFade;
	uint8_t ___m_StateFlags;
	int32_t ___DestinationStateHash;
};
struct AnimationTriggerMessage_t5E9BAC8B6B7C3A3D79E9448C8C735380FBFC72FF 
{
	int32_t ___Hash;
	bool ___IsTriggerSet;
};
struct AnimationTriggerMessage_t5E9BAC8B6B7C3A3D79E9448C8C735380FBFC72FF_marshaled_pinvoke
{
	int32_t ___Hash;
	int32_t ___IsTriggerSet;
};
struct AnimationTriggerMessage_t5E9BAC8B6B7C3A3D79E9448C8C735380FBFC72FF_marshaled_com
{
	int32_t ___Hash;
	int32_t ___IsTriggerSet;
};
struct ParametersUpdateMessage_tA77A911264605B5AE8FE181D2A1BA78A4E2B41CC 
{
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___Parameters;
};
struct ParametersUpdateMessage_tA77A911264605B5AE8FE181D2A1BA78A4E2B41CC_marshaled_pinvoke
{
	Il2CppSafeArray* ___Parameters;
};
struct ParametersUpdateMessage_tA77A911264605B5AE8FE181D2A1BA78A4E2B41CC_marshaled_com
{
	Il2CppSafeArray* ___Parameters;
};
struct FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C 
{
	bool ___InLocalSpace;
	bool ___HasPositionX;
	bool ___HasPositionY;
	bool ___HasPositionZ;
	bool ___HasPositionChange;
	bool ___HasRotAngleX;
	bool ___HasRotAngleY;
	bool ___HasRotAngleZ;
	bool ___HasRotAngleChange;
	bool ___HasScaleX;
	bool ___HasScaleY;
	bool ___HasScaleZ;
	bool ___HasScaleChange;
	bool ___IsTeleportingNextFrame;
	bool ___WasTeleported;
	bool ___UseInterpolation;
	bool ___QuaternionSync;
	bool ___QuaternionCompression;
	bool ___UseHalfFloatPrecision;
	bool ___IsSynchronizing;
	bool ___UsePositionSlerp;
	bool ___IsParented;
	bool ___SynchronizeBaseHalfFloat;
	bool ___ReliableSequenced;
	bool ___UseUnreliableDeltas;
	bool ___UnreliableFrameSync;
	bool ___SwitchTransformSpaceWhenParented;
	bool ___TrackByStateId;
	bool ___IsDirty;
};
struct FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C_marshaled_pinvoke
{
	int32_t ___InLocalSpace;
	int32_t ___HasPositionX;
	int32_t ___HasPositionY;
	int32_t ___HasPositionZ;
	int32_t ___HasPositionChange;
	int32_t ___HasRotAngleX;
	int32_t ___HasRotAngleY;
	int32_t ___HasRotAngleZ;
	int32_t ___HasRotAngleChange;
	int32_t ___HasScaleX;
	int32_t ___HasScaleY;
	int32_t ___HasScaleZ;
	int32_t ___HasScaleChange;
	int32_t ___IsTeleportingNextFrame;
	int32_t ___WasTeleported;
	int32_t ___UseInterpolation;
	int32_t ___QuaternionSync;
	int32_t ___QuaternionCompression;
	int32_t ___UseHalfFloatPrecision;
	int32_t ___IsSynchronizing;
	int32_t ___UsePositionSlerp;
	int32_t ___IsParented;
	int32_t ___SynchronizeBaseHalfFloat;
	int32_t ___ReliableSequenced;
	int32_t ___UseUnreliableDeltas;
	int32_t ___UnreliableFrameSync;
	int32_t ___SwitchTransformSpaceWhenParented;
	int32_t ___TrackByStateId;
	int32_t ___IsDirty;
};
struct FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C_marshaled_com
{
	int32_t ___InLocalSpace;
	int32_t ___HasPositionX;
	int32_t ___HasPositionY;
	int32_t ___HasPositionZ;
	int32_t ___HasPositionChange;
	int32_t ___HasRotAngleX;
	int32_t ___HasRotAngleY;
	int32_t ___HasRotAngleZ;
	int32_t ___HasRotAngleChange;
	int32_t ___HasScaleX;
	int32_t ___HasScaleY;
	int32_t ___HasScaleZ;
	int32_t ___HasScaleChange;
	int32_t ___IsTeleportingNextFrame;
	int32_t ___WasTeleported;
	int32_t ___UseInterpolation;
	int32_t ___QuaternionSync;
	int32_t ___QuaternionCompression;
	int32_t ___UseHalfFloatPrecision;
	int32_t ___IsSynchronizing;
	int32_t ___UsePositionSlerp;
	int32_t ___IsParented;
	int32_t ___SynchronizeBaseHalfFloat;
	int32_t ___ReliableSequenced;
	int32_t ___UseUnreliableDeltas;
	int32_t ___UnreliableFrameSync;
	int32_t ___SwitchTransformSpaceWhenParented;
	int32_t ___TrackByStateId;
	int32_t ___IsDirty;
};
struct ContactId_tD87E020E1E854F067B05AE73E9C5B3FE3155CF11 
{
	int32_t ___m_IndexId;
	uint16_t ___m_WorldId;
	uint16_t ___m_Padding;
	int32_t ___m_GenerationId;
};
struct ExpressionQuoter_t3D5F35B2980800F7F947EBC0819D867CF5AAD536  : public ExpressionVisitor_tD26583FF464068F23017BC372C81133A62C5A590
{
	Dictionary_2_tEF46B4EA472A35123947A8DF4F68C3E8A5F0C4FD* ____variables;
	InterpretedFrame_tF030A9AC78837B1C2F9CD54B43F7A04D85A8D92D* ____frame;
	Stack_1_tC4810ACEE7FD00840B5CB4333A83E2E1553CAD26* ____shadowedVars;
};
struct ByReference_1_t21C88CEA3607E6DA2435F0E317C10A776BCA6DCC 
{
	intptr_t ____value;
};
struct ByReference_1_t607C1F3BC28B0E21B969461CDB0720FB01A82141 
{
	intptr_t ____value;
};
struct ByReference_1_tE65F7690AD68D042A57AB5586834E7F855D7028A 
{
	intptr_t ____value;
};
struct ByReference_1_t3FCA8FF1FA32CFC8B394F6C061E343A0D3701912 
{
	intptr_t ____value;
};
struct ByReference_1_t94B9C7E612FAA889D668D045B2EC5F1DBF3AFFF9 
{
	intptr_t ____value;
};
struct ByReference_1_t4A0B0D8287F5D040285FB49C3AA25A8EE38D5B23 
{
	intptr_t ____value;
};
struct ByReference_1_tA7727FC82C1D779EE2802A1968C3FFC569152294 
{
	intptr_t ____value;
};
struct ByReference_1_tB78BE0105D10907AA8C665AF95DBAEF4BEF517CF 
{
	intptr_t ____value;
};
struct ByReference_1_t5A8D94A74D3EF9FFDEF739B5061D38830B7FE058 
{
	intptr_t ____value;
};
struct Expression_1_t0FC093B0DDEA1EB4F5EF3152CC33F1B785E80EA4  : public LambdaExpression_tD26FB6AEAD01B2EBB668CDEAFAAFA4948697300E
{
};
struct Allocator_t996642592271AAD9EE688F142741D512C07B5824 
{
	int32_t ___value__;
};
struct BufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091 
{
	FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 ___m_Reader;
};
struct BufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4 
{
	FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC ___m_Writer;
};
struct Exception_t  : public RuntimeObject
{
	String_t* ____className;
	String_t* ____message;
	RuntimeObject* ____data;
	Exception_t* ____innerException;
	String_t* ____helpURL;
	RuntimeObject* ____stackTrace;
	String_t* ____stackTraceString;
	String_t* ____remoteStackTraceString;
	int32_t ____remoteStackIndex;
	RuntimeObject* ____dynamicMethods;
	int32_t ____HResult;
	String_t* ____source;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces;
	IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832* ___native_trace_ips;
	int32_t ___caught_in_unmanaged;
};
struct Exception_t_marshaled_pinvoke
{
	char* ____className;
	char* ____message;
	RuntimeObject* ____data;
	Exception_t_marshaled_pinvoke* ____innerException;
	char* ____helpURL;
	Il2CppIUnknown* ____stackTrace;
	char* ____stackTraceString;
	char* ____remoteStackTraceString;
	int32_t ____remoteStackIndex;
	Il2CppIUnknown* ____dynamicMethods;
	int32_t ____HResult;
	char* ____source;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces;
	Il2CppSafeArray* ___native_trace_ips;
	int32_t ___caught_in_unmanaged;
};
struct Exception_t_marshaled_com
{
	Il2CppChar* ____className;
	Il2CppChar* ____message;
	RuntimeObject* ____data;
	Exception_t_marshaled_com* ____innerException;
	Il2CppChar* ____helpURL;
	Il2CppIUnknown* ____stackTrace;
	Il2CppChar* ____stackTraceString;
	Il2CppChar* ____remoteStackTraceString;
	int32_t ____remoteStackIndex;
	Il2CppIUnknown* ____dynamicMethods;
	int32_t ____HResult;
	Il2CppChar* ____source;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces;
	Il2CppSafeArray* ___native_trace_ips;
	int32_t ___caught_in_unmanaged;
};
struct GCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC 
{
	intptr_t ___handle;
};
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C  : public RuntimeObject
{
	intptr_t ___m_CachedPtr;
};
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_pinvoke
{
	intptr_t ___m_CachedPtr;
};
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_com
{
	intptr_t ___m_CachedPtr;
};
struct PhysicsBody_t4D9A16A318F8485217B0416E238278FA77455CD0 
{
	PhysicsHandle_tEC3DCC38ABB8395068171070539ABF8309A854C2 ___m_PhysicsHandle;
};
struct PhysicsJoint_tC54739697A353F8507A40D3B105421EE91B33884 
{
	PhysicsHandle_tEC3DCC38ABB8395068171070539ABF8309A854C2 ___m_PhysicsHandle;
};
struct PhysicsRotate_t3AF8BA583108282C8B59872CB621EC366BC042B0 
{
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___direction;
};
struct PhysicsShape_t5332F05C66BD392AFDBAE441571781A22AABED7E 
{
	PhysicsHandle_tEC3DCC38ABB8395068171070539ABF8309A854C2 ___m_PhysicsHandle;
};
struct PropertyPathPartKind_t82152825D88A0E450DDCE8503272A10595047F87 
{
	int32_t ___value__;
};
struct RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B 
{
	intptr_t ___value;
};
struct SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 
{
	EntityId_t982FBD037EAC5CA077B1602A7EA40E3523AA0FC8 ___m_Value;
};
struct VisitReturnCode_t795FEB928E847C526F470080AA94B33FAC60BC75 
{
	int32_t ___value__;
};
struct half3_tAC3065568DE0CD35A46DE11D367236E8FB7BEA07 
{
	half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___x;
	half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___y;
	half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___z;
};
struct half4_t04B1BC17C3559EC70A5CA2394C7C41B480EA83D8 
{
	half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___x;
	half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___y;
	half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___z;
	half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___w;
};
struct quaternion_t9C8C2916B7359C174B215BBB41F290ABCBEA8AEA 
{
	float4_t545A994996126766890C1F28B43EA823F2410190 ___value;
};
struct MapTypes_tB24369EF24F9A74D2FA0CA938B55392EA305822C 
{
	int32_t ___value__;
};
struct Axis_t13690270A04957CB5CD8950F7E8A9D9ED0041D19 
{
	int32_t ___value__;
};
struct TransformWriteMode_tAC88F83F00B2B74873BDD3631AC07283279591D4 
{
	int32_t ___value__;
};
struct BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B 
{
	BufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091 ___m_Implementation;
};
struct BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0 
{
	BufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4 ___m_Implementation;
};
struct NativeArray_1_tDB8B8DC66CC8E16ED6D9A8C75D2C1AFC80AC1E18 
{
	void* ___m_Buffer;
	int32_t ___m_Length;
	int32_t ___m_AllocatorLabel;
};
struct NativeArray_1_t7D2E0867BA2C51E53A2DA86335020B175E7CDC86 
{
	void* ___m_Buffer;
	int32_t ___m_Length;
	int32_t ___m_AllocatorLabel;
};
struct NativeArray_1_tD433A29296E2B6926BA29A86B35FEEA6C63C8C68 
{
	void* ___m_Buffer;
	int32_t ___m_Length;
	int32_t ___m_AllocatorLabel;
};
struct NativeArray_1_tAE73165FE666BFCBFB4CA0B72FFA351ED1872602 
{
	void* ___m_Buffer;
	int32_t ___m_Length;
	int32_t ___m_AllocatorLabel;
};
struct NativeArray_1_tBA0BC79DB482632B1DB9D7FF91357CE99B4C73CF 
{
	void* ___m_Buffer;
	int32_t ___m_Length;
	int32_t ___m_AllocatorLabel;
};
struct NativeArray_1_t2EDCD6FB85206C53A92873BFCBE46ACD9462C683 
{
	void* ___m_Buffer;
	int32_t ___m_Length;
	int32_t ___m_AllocatorLabel;
};
struct NativeArray_1_tE9E9E78E659CC7A96EFD37D8824AEE58DE412CA8 
{
	void* ___m_Buffer;
	int32_t ___m_Length;
	int32_t ___m_AllocatorLabel;
};
struct NativeArray_1_tA05A93824C515FF087043027C088AD9C5375BB1D 
{
	void* ___m_Buffer;
	int32_t ___m_Length;
	int32_t ___m_AllocatorLabel;
};
struct ReadOnlySpan_1_tE8C37D9A05FCAB953169AFFE8A0ABCA809781E25 
{
	ByReference_1_t21C88CEA3607E6DA2435F0E317C10A776BCA6DCC ____pointer;
	int32_t ____length;
};
struct ReadOnlySpan_1_tC416A5627E04F69CA2947A2A13F0A1DF096CABAC 
{
	ByReference_1_t607C1F3BC28B0E21B969461CDB0720FB01A82141 ____pointer;
	int32_t ____length;
};
struct ReadOnlySpan_1_t7C8438B00110311A3FFF078F848928218D9D79F1 
{
	ByReference_1_t3FCA8FF1FA32CFC8B394F6C061E343A0D3701912 ____pointer;
	int32_t ____length;
};
struct ReadOnlySpan_1_tD1C684B7FBBE6B196C3D9C25D26C14087DDACC42 
{
	ByReference_1_t94B9C7E612FAA889D668D045B2EC5F1DBF3AFFF9 ____pointer;
	int32_t ____length;
};
struct ReadOnlySpan_1_t2FC42E74698A85F864327A2F3603A016F223B360 
{
	ByReference_1_t4A0B0D8287F5D040285FB49C3AA25A8EE38D5B23 ____pointer;
	int32_t ____length;
};
struct ReadOnlySpan_1_t7D0A62688D12B6224D58E7D7EB6BBE34C2B5705B 
{
	ByReference_1_tA7727FC82C1D779EE2802A1968C3FFC569152294 ____pointer;
	int32_t ____length;
};
struct ReadOnlySpan_1_t2239736A651E959D4A4360EBC03DFBCFAE1C9DA6 
{
	ByReference_1_tB78BE0105D10907AA8C665AF95DBAEF4BEF517CF ____pointer;
	int32_t ____length;
};
struct ReadOnlySpan_1_t4A1964D3768FECC83DDD199B546B177020E04377 
{
	ByReference_1_t5A8D94A74D3EF9FFDEF739B5061D38830B7FE058 ____pointer;
	int32_t ____length;
};
struct Span_1_t3EBD12B39F51F09620FC7421B894677E0D26E0AD 
{
	ByReference_1_t21C88CEA3607E6DA2435F0E317C10A776BCA6DCC ____pointer;
	int32_t ____length;
};
struct Span_1_tDEB40BEFA77B5E4BB49B058CD3050EEA4DD36C54 
{
	ByReference_1_t607C1F3BC28B0E21B969461CDB0720FB01A82141 ____pointer;
	int32_t ____length;
};
struct Span_1_t9F6FBEA217E68146892F6B8BBCE2E2C9E95689A1 
{
	ByReference_1_tE65F7690AD68D042A57AB5586834E7F855D7028A ____pointer;
	int32_t ____length;
};
struct HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02 
{
	half3_tAC3065568DE0CD35A46DE11D367236E8FB7BEA07 ___Axis;
	bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02 ___AxisToSynchronize;
};
struct HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD 
{
	half4_t04B1BC17C3559EC70A5CA2394C7C41B480EA83D8 ___Axis;
};
struct NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D 
{
	SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 ___m_Handle;
};
struct PhysicsTransform_tB8A6E5FBEECAEFA43E89B0975A2D617AC701E434 
{
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___position;
	PhysicsRotate_t3AF8BA583108282C8B59872CB621EC366BC042B0 ___rotation;
};
struct PropertyPathPart_tFB308743948D2298957DC1898D90AF2ACFED9DFF 
{
	int32_t ___m_Kind;
	String_t* ___m_Name;
	int32_t ___m_Index;
	RuntimeObject* ___m_Key;
};
struct PropertyPathPart_tFB308743948D2298957DC1898D90AF2ACFED9DFF_marshaled_pinvoke
{
	int32_t ___m_Kind;
	char* ___m_Name;
	int32_t ___m_Index;
	Il2CppIUnknown* ___m_Key;
};
struct PropertyPathPart_tFB308743948D2298957DC1898D90AF2ACFED9DFF_marshaled_com
{
	int32_t ___m_Kind;
	Il2CppChar* ___m_Name;
	int32_t ___m_Index;
	Il2CppIUnknown* ___m_Key;
};
struct Scene_tA1DC762B79745EB5140F054C884855B922318356 
{
	SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 ___m_Handle;
};
struct SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295  : public Exception_t
{
};
struct Type_t  : public MemberInfo_t
{
	RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B ____impl;
};
struct ReaderHandle_t7A818FF1A9ACF79E6D6322AFF494B9FB12C48CC8 
{
	uint8_t* ___BufferPointer;
	int32_t ___Position;
	int32_t ___Length;
	int32_t ___Allocator;
};
struct WriterHandle_tBDBA7A52860089574884E6269EF80A4ABDA26BE6 
{
	uint8_t* ___BufferPointer;
	int32_t ___Position;
	int32_t ___Length;
	int32_t ___Capacity;
	int32_t ___MaxCapacity;
	int32_t ___Allocator;
	bool ___BufferGrew;
};
struct WriterHandle_tBDBA7A52860089574884E6269EF80A4ABDA26BE6_marshaled_pinvoke
{
	uint8_t* ___BufferPointer;
	int32_t ___Position;
	int32_t ___Length;
	int32_t ___Capacity;
	int32_t ___MaxCapacity;
	int32_t ___Allocator;
	int32_t ___BufferGrew;
};
struct WriterHandle_tBDBA7A52860089574884E6269EF80A4ABDA26BE6_marshaled_com
{
	uint8_t* ___BufferPointer;
	int32_t ___Position;
	int32_t ___Length;
	int32_t ___Capacity;
	int32_t ___MaxCapacity;
	int32_t ___Allocator;
	int32_t ___BufferGrew;
};
struct ContactBeginEvent_tE6898EF155CD177351DCA1B58320E71502483291 
{
	PhysicsShape_t5332F05C66BD392AFDBAE441571781A22AABED7E ___m_ShapeA;
	PhysicsShape_t5332F05C66BD392AFDBAE441571781A22AABED7E ___m_ShapeB;
	ContactId_tD87E020E1E854F067B05AE73E9C5B3FE3155CF11 ___m_ContactId;
};
struct ContactEndEvent_t99F3D0E45651D2DEEAD6961EDD93A532F733A002 
{
	PhysicsShape_t5332F05C66BD392AFDBAE441571781A22AABED7E ___m_ShapeA;
	PhysicsShape_t5332F05C66BD392AFDBAE441571781A22AABED7E ___m_ShapeB;
	ContactId_tD87E020E1E854F067B05AE73E9C5B3FE3155CF11 ___m_ContactId;
};
struct JointThresholdEvent_t32ED7A55510168BABACED0AD5308EFDC68F72E7A 
{
	PhysicsJoint_tC54739697A353F8507A40D3B105421EE91B33884 ___m_Joint;
	intptr_t ___m_UserData;
};
struct TriggerBeginEvent_t51AB74C5036CEFCBE51AFDFE746B2A08627571B9 
{
	PhysicsShape_t5332F05C66BD392AFDBAE441571781A22AABED7E ___m_TriggerShape;
	PhysicsShape_t5332F05C66BD392AFDBAE441571781A22AABED7E ___m_VisitorShape;
};
struct TriggerEndEvent_tB944FE9E547B3336FFEE17614E6C724A1ECE8A04 
{
	PhysicsShape_t5332F05C66BD392AFDBAE441571781A22AABED7E ___m_TriggerShape;
	PhysicsShape_t5332F05C66BD392AFDBAE441571781A22AABED7E ___m_VisitorShape;
};
struct PhysicsBuffer_tCAD034F191834ECD0CAE25B468D0610D84B68A4D 
{
	intptr_t ___m_Buffer;
	int32_t ___m_Size;
	int32_t ___m_Allocator;
};
struct IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};
struct InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};
struct NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9 
{
	HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02 ___HalfVector3;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___CurrentBasePosition;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___PrecisionLossDelta;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___HalfDeltaConvertedBack;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___PreviousPosition;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___DeltaPosition;
	int32_t ___NetworkTick;
	bool ___SynchronizeBase;
	bool ___CollapsedDeltaIntoBase;
};
struct PropertyPath_tA523CA2740853534DF6C009C588464B45A6D0A79 
{
	PropertyPathPart_tFB308743948D2298957DC1898D90AF2ACFED9DFF ___m_Part0;
	PropertyPathPart_tFB308743948D2298957DC1898D90AF2ACFED9DFF ___m_Part1;
	PropertyPathPart_tFB308743948D2298957DC1898D90AF2ACFED9DFF ___m_Part2;
	PropertyPathPart_tFB308743948D2298957DC1898D90AF2ACFED9DFF ___m_Part3;
	PropertyPathPartU5BU5D_t7994D542F14DDDDEABB1792C335C20149399AEBB* ___m_AdditionalParts;
	int32_t ___U3CLengthU3Ek__BackingField;
};
struct PropertyPath_tA523CA2740853534DF6C009C588464B45A6D0A79_marshaled_pinvoke
{
	PropertyPathPart_tFB308743948D2298957DC1898D90AF2ACFED9DFF_marshaled_pinvoke ___m_Part0;
	PropertyPathPart_tFB308743948D2298957DC1898D90AF2ACFED9DFF_marshaled_pinvoke ___m_Part1;
	PropertyPathPart_tFB308743948D2298957DC1898D90AF2ACFED9DFF_marshaled_pinvoke ___m_Part2;
	PropertyPathPart_tFB308743948D2298957DC1898D90AF2ACFED9DFF_marshaled_pinvoke ___m_Part3;
	PropertyPathPart_tFB308743948D2298957DC1898D90AF2ACFED9DFF_marshaled_pinvoke* ___m_AdditionalParts;
	int32_t ___U3CLengthU3Ek__BackingField;
};
struct PropertyPath_tA523CA2740853534DF6C009C588464B45A6D0A79_marshaled_com
{
	PropertyPathPart_tFB308743948D2298957DC1898D90AF2ACFED9DFF_marshaled_com ___m_Part0;
	PropertyPathPart_tFB308743948D2298957DC1898D90AF2ACFED9DFF_marshaled_com ___m_Part1;
	PropertyPathPart_tFB308743948D2298957DC1898D90AF2ACFED9DFF_marshaled_com ___m_Part2;
	PropertyPathPart_tFB308743948D2298957DC1898D90AF2ACFED9DFF_marshaled_com ___m_Part3;
	PropertyPathPart_tFB308743948D2298957DC1898D90AF2ACFED9DFF_marshaled_com* ___m_AdditionalParts;
	int32_t ___U3CLengthU3Ek__BackingField;
};
struct SceneMap_tD765F13EE91B6DB8366332CB2C054CC47DE5AA7E 
{
	int32_t ___MapType;
	Scene_tA1DC762B79745EB5140F054C884855B922318356 ___Scene;
	bool ___ScenePresent;
	String_t* ___SceneName;
	int32_t ___ServerHandle;
	int32_t ___MappedLocalHandle;
	int32_t ___LocalHandle;
	SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 ___ServerSceneHandle;
	SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 ___MappedLocalSceneHandle;
	SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 ___LocalSceneHandle;
	NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D ___m_ServerHandle;
	NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D ___m_MappedLocalHandle;
	NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D ___m_LocalHandle;
};
struct SceneMap_tD765F13EE91B6DB8366332CB2C054CC47DE5AA7E_marshaled_pinvoke
{
	int32_t ___MapType;
	Scene_tA1DC762B79745EB5140F054C884855B922318356 ___Scene;
	int32_t ___ScenePresent;
	char* ___SceneName;
	int32_t ___ServerHandle;
	int32_t ___MappedLocalHandle;
	int32_t ___LocalHandle;
	SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 ___ServerSceneHandle;
	SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 ___MappedLocalSceneHandle;
	SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 ___LocalSceneHandle;
	NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D ___m_ServerHandle;
	NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D ___m_MappedLocalHandle;
	NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D ___m_LocalHandle;
};
struct SceneMap_tD765F13EE91B6DB8366332CB2C054CC47DE5AA7E_marshaled_com
{
	int32_t ___MapType;
	Scene_tA1DC762B79745EB5140F054C884855B922318356 ___Scene;
	int32_t ___ScenePresent;
	Il2CppChar* ___SceneName;
	int32_t ___ServerHandle;
	int32_t ___MappedLocalHandle;
	int32_t ___LocalHandle;
	SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 ___ServerSceneHandle;
	SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 ___MappedLocalSceneHandle;
	SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 ___LocalSceneHandle;
	NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D ___m_ServerHandle;
	NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D ___m_MappedLocalHandle;
	NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D ___m_LocalHandle;
};
struct TransformWriteTween_t86FB859350EF146AC5D9CB4CA8196377B714E2B7 
{
	PhysicsBody_t4D9A16A318F8485217B0416E238278FA77455CD0 ___m_Body;
	int32_t ___m_TransformWriteMode;
	PhysicsTransform_tB8A6E5FBEECAEFA43E89B0975A2D617AC701E434 ___m_PhysicsTransform;
	EntityId_t982FBD037EAC5CA077B1602A7EA40E3523AA0FC8 ___m_TransformId;
	int32_t ___m_TransformDepth;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___m_LinearVelocity;
	float ___m_AngularVelocity;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_PositionFrom;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___m_RotationFrom;
};
struct BodyUpdateEvent_t7EF4D88BBC121B3438A99B1A5E81EFEEA5D332A6 
{
	intptr_t ___m_UserData;
	PhysicsTransform_tB8A6E5FBEECAEFA43E89B0975A2D617AC701E434 ___m_Transform;
	PhysicsBody_t4D9A16A318F8485217B0416E238278FA77455CD0 ___m_Body;
	bool ___m_FellAsleep;
};
struct BodyUpdateEvent_t7EF4D88BBC121B3438A99B1A5E81EFEEA5D332A6_marshaled_pinvoke
{
	intptr_t ___m_UserData;
	PhysicsTransform_tB8A6E5FBEECAEFA43E89B0975A2D617AC701E434 ___m_Transform;
	PhysicsBody_t4D9A16A318F8485217B0416E238278FA77455CD0 ___m_Body;
	int32_t ___m_FellAsleep;
};
struct BodyUpdateEvent_t7EF4D88BBC121B3438A99B1A5E81EFEEA5D332A6_marshaled_com
{
	intptr_t ___m_UserData;
	PhysicsTransform_tB8A6E5FBEECAEFA43E89B0975A2D617AC701E434 ___m_Transform;
	PhysicsBody_t4D9A16A318F8485217B0416E238278FA77455CD0 ___m_Body;
	int32_t ___m_FellAsleep;
};
struct ContactBeginTarget_t56AE151974F2573AEE7A94C0033B3D0F654D58CC 
{
	ContactBeginEvent_tE6898EF155CD177351DCA1B58320E71502483291 ___m_BeginEvent;
};
struct ContactEndTarget_tE6BBAE8C6CDE91B49A0F4BA4B7FB54332883236A 
{
	ContactEndEvent_t99F3D0E45651D2DEEAD6961EDD93A532F733A002 ___m_EndEvent;
};
struct JointThresholdTarget_t3D05E6C79F07DBC2277A1980ED540C93D55F60BF 
{
	JointThresholdEvent_t32ED7A55510168BABACED0AD5308EFDC68F72E7A ___m_JointThresholdEvent;
};
struct TriggerBeginTarget_t5502949EBCED40452D61487C8D3CCB893F177576 
{
	TriggerBeginEvent_t51AB74C5036CEFCBE51AFDFE746B2A08627571B9 ___m_BeginEvent;
};
struct TriggerEndTarget_t403C9C465F01F85B8C5E4BDDDE133CFF7EBD902A 
{
	TriggerEndEvent_tB944FE9E547B3336FFEE17614E6C724A1ECE8A04 ___m_EndEvent;
};
struct PathVisitor_tCD0947C41CDBDB774D22D560E5FFA01EF61C4446  : public RuntimeObject
{
	int32_t ___m_PathIndex;
	PropertyPath_tA523CA2740853534DF6C009C588464B45A6D0A79 ___U3CPathU3Ek__BackingField;
	RuntimeObject* ___U3CPropertyU3Ek__BackingField;
	bool ___U3CReadonlyVisitU3Ek__BackingField;
	int32_t ___U3CReturnCodeU3Ek__BackingField;
};
struct NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED 
{
	double ___SentTime;
	float ___PositionX;
	float ___PositionY;
	float ___PositionZ;
	float ___RotAngleX;
	float ___RotAngleY;
	float ___RotAngleZ;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___Rotation;
	float ___ScaleX;
	float ___ScaleY;
	float ___ScaleZ;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___CurrentPosition;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___DeltaPosition;
	NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9 ___NetworkDeltaPosition;
	HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02 ___HalfVectorScale;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___Scale;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___LossyScale;
	HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD ___HalfVectorRotation;
	uint32_t ___QuaternionCompressed;
	int32_t ___U3CLastSerializedSizeU3Ek__BackingField;
	int32_t ___NetworkTick;
	int32_t ___StateId;
	bool ___ExplicitSet;
	FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 ___m_Reader;
	FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC ___m_Writer;
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C ___FlagStates;
	HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02 ___HalfEulerRotation;
};
struct BodyUpdateTarget_t6013C0FBA9A3E7A8E68F98F01A1B3EA92F574D84 
{
	BodyUpdateEvent_t7EF4D88BBC121B3438A99B1A5E81EFEEA5D332A6 ___m_BodyUpdateEvent;
};
struct BodyUpdateTarget_t6013C0FBA9A3E7A8E68F98F01A1B3EA92F574D84_marshaled_pinvoke
{
	BodyUpdateEvent_t7EF4D88BBC121B3438A99B1A5E81EFEEA5D332A6_marshaled_pinvoke ___m_BodyUpdateEvent;
};
struct BodyUpdateTarget_t6013C0FBA9A3E7A8E68F98F01A1B3EA92F574D84_marshaled_com
{
	BodyUpdateEvent_t7EF4D88BBC121B3438A99B1A5E81EFEEA5D332A6_marshaled_com ___m_BodyUpdateEvent;
};
struct GetPropertyVisitor_t88183F280884F26458B42DAF173F005F3625F540  : public PathVisitor_tCD0947C41CDBDB774D22D560E5FFA01EF61C4446
{
	RuntimeObject* ___Property;
};
struct Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785_StaticFields
{
	CacheDict_2_tB695739D50653F4D4C3DA03BCF07CC868196FB15* ___s_lambdaDelegateCache;
	CacheDict_2_t3592A9BE3B1E812BCE8A13D901156E74C707DBB7* ___s_lambdaFactories;
	ConditionalWeakTable_2_t0F3FDA57EE333DF8B8C1F3FB944E4E19C5DDCFC7* ___s_legacyCtorSupportTable;
};
struct String_t_StaticFields
{
	String_t* ___Empty;
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	String_t* ___TrueString;
	String_t* ___FalseString;
};
struct Char_t521A6F19B456D956AF452D926C32709DC03D6B17_StaticFields
{
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___s_categoryForLatin1;
};
struct FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC_StaticFields
{
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___k_ByteArrayCache;
};
struct IntPtr_t_StaticFields
{
	intptr_t ___Zero;
};
struct Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974_StaticFields
{
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___identityQuaternion;
};
struct Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_StaticFields
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___zeroVector;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___oneVector;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___upVector;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___downVector;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___leftVector;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___rightVector;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___forwardVector;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___backVector;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___positiveInfinityVector;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___negativeInfinityVector;
};
struct float3_t7600B73F092B37F484B12910A5269F30C778D31E_StaticFields
{
	float3_t7600B73F092B37F484B12910A5269F30C778D31E ___zero;
};
struct float4_t545A994996126766890C1F28B43EA823F2410190_StaticFields
{
	float4_t545A994996126766890C1F28B43EA823F2410190 ___zero;
};
struct half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579_StaticFields
{
	half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___zero;
};
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_StaticFields
{
	int32_t ___OffsetOfInstanceIDInCPlusPlusObject;
};
struct half3_tAC3065568DE0CD35A46DE11D367236E8FB7BEA07_StaticFields
{
	half3_tAC3065568DE0CD35A46DE11D367236E8FB7BEA07 ___zero;
};
struct quaternion_t9C8C2916B7359C174B215BBB41F290ABCBEA8AEA_StaticFields
{
	quaternion_t9C8C2916B7359C174B215BBB41F290ABCBEA8AEA ___identity;
};
struct Type_t_StaticFields
{
	Binder_t91BFCE95A7057FADF4D8A1A342AFE52872246235* ___s_defaultBinder;
	Il2CppChar ___Delimiter;
	TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB* ___EmptyTypes;
	RuntimeObject* ___Missing;
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterAttribute;
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterName;
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterNameIgnoreCase;
};
struct GetPropertyVisitor_t88183F280884F26458B42DAF173F005F3625F540_StaticFields
{
	ObjectPool_1_tF11864F05C33C2DB6AAE614D05951B55BB8BC340* ___Pool;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031  : public RuntimeArray
{
	ALIGN_FIELD (8) uint8_t m_Items[1];

	inline uint8_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline uint8_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, uint8_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline uint8_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline uint8_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, uint8_t value)
	{
		m_Items[index] = value;
	}
};
struct ParameterExpressionU5BU5D_tA217A6969CA4383EF6D3C43B8EB0989358ABE72C  : public RuntimeArray
{
	ALIGN_FIELD (8) ParameterExpression_tE8D3A1137422F75D256CBB200EDC82820F240110* m_Items[1];

	inline ParameterExpression_tE8D3A1137422F75D256CBB200EDC82820F240110* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline ParameterExpression_tE8D3A1137422F75D256CBB200EDC82820F240110** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, ParameterExpression_tE8D3A1137422F75D256CBB200EDC82820F240110* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline ParameterExpression_tE8D3A1137422F75D256CBB200EDC82820F240110* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline ParameterExpression_tE8D3A1137422F75D256CBB200EDC82820F240110** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, ParameterExpression_tE8D3A1137422F75D256CBB200EDC82820F240110* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
struct SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C  : public RuntimeArray
{
	ALIGN_FIELD (8) float m_Items[1];

	inline float GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline float* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, float value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline float GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline float* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, float value)
	{
		m_Items[index] = value;
	}
};


IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AnimationState_NetworkSerialize_TisIl2CppFullySharedGenericAny_m760AC204C9E95DFB88C5DA7B9EC8814C6D49A1F5_fshared (AnimationState_t90091AD2757C132602279750EFF7907F066817B0* __this, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 ___0_serializer, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m59AF230EB443B685CB322B5AA0898734756EADD7 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, int32_t* ___0_value, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m53224A30FDD9F347134C5F058A4AA1902F046703 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, bool* ___0_value, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AnimationTriggerMessage_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_mB3FE1737DB61D6C43FC1D5DF82F2517258B17F5F (AnimationTriggerMessage_t5E9BAC8B6B7C3A3D79E9448C8C735380FBFC72FF* __this, BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B ___0_serializer, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m77A3B1A6805879DFC74A55FBE9F076C81CF22869 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, int32_t* ___0_value, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m7B4A33CD1D215EDE706B9F3F54F930263A54879F (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, bool* ___0_value, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AnimationTriggerMessage_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m831257AA195AD81E1B8876E6192CE70252D31F1D (AnimationTriggerMessage_t5E9BAC8B6B7C3A3D79E9448C8C735380FBFC72FF* __this, BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0 ___0_serializer, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AnimationTriggerMessage_NetworkSerialize_TisIl2CppFullySharedGenericAny_m12CFDF3873F81396A10F13261B1DF4F83D0A99D8_fshared (AnimationTriggerMessage_t5E9BAC8B6B7C3A3D79E9448C8C735380FBFC72FF* __this, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 ___0_serializer, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m1D4559355D8982D0FDFBECB67C3DFD8B5977522F (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** ___0_value, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ParametersUpdateMessage_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_mDAD146156C033575D7A28EE56A00A98731B84A0A (ParametersUpdateMessage_tA77A911264605B5AE8FE181D2A1BA78A4E2B41CC* __this, BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B ___0_serializer, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_mAD89D6AD1671054722C3ECC148291524285C35D8 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** ___0_value, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ParametersUpdateMessage_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m69B6E53197F936BB20E239A5CE6795AE55497DF9 (ParametersUpdateMessage_tA77A911264605B5AE8FE181D2A1BA78A4E2B41CC* __this, BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0 ___0_serializer, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ParametersUpdateMessage_NetworkSerialize_TisIl2CppFullySharedGenericAny_mB78A86C8B7A4255E424BE9FEC1CFE27AD6EBA453_fshared (ParametersUpdateMessage_tA77A911264605B5AE8FE181D2A1BA78A4E2B41CC* __this, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 ___0_serializer, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m58D81C281DF1007FE8512D26EBF07BB09459BC28_gshared (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, int32_t* ___0_value, ForEnums_tD6A048FB8E80A3A6DC7DE4B6DE48D635362F7511 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool BufferSerializer_1_get_IsReader_m6391807CBC3E99FB5B0C0306A3407B988C01270B (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_mFC3CDB7ADDAFE46729C25BAAACFC409528BD2995 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, String_t** ___0_s, bool ___1_oneByteChars, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool BufferSerializer_1_get_IsWriter_m6978D539067CE30EC81B6491589C7C30A1E16C28 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisNetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D_m8291063A935C8DCA24338F6C4EE6E3F14117C1E8 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* ___0_value, ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SceneMap_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_m9853256DC4E5A60E8A9D416599B7D6E4153A2AF6 (SceneMap_tD765F13EE91B6DB8366332CB2C054CC47DE5AA7E* __this, BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B ___0_serializer, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m2654B874743146008CACD143DFD23C2313A11933_gshared (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, int32_t* ___0_value, ForEnums_tD6A048FB8E80A3A6DC7DE4B6DE48D635362F7511 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool BufferSerializer_1_get_IsReader_mBAAFBF1B83961D969792A2CDB52D3EE2B05653DF (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_mB617CF6234422CCCAD113FE97A1D5E18DB802962 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, String_t** ___0_s, bool ___1_oneByteChars, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool BufferSerializer_1_get_IsWriter_mA81CADE3680B019327BD43C92F4743B2140A83EB (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisNetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D_mADBE51CDBAEF491B1ACBE311CC6940C791075273 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* ___0_value, ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SceneMap_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m9A4D0AB395FD9325D6F1E30FC65753F2C6684C21 (SceneMap_tD765F13EE91B6DB8366332CB2C054CC47DE5AA7E* __this, BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0 ___0_serializer, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SceneMap_NetworkSerialize_TisIl2CppFullySharedGenericAny_m2DE7C2FEDDE74AF6ADEE717F91A54EFCBBC9C13D_fshared (SceneMap_tD765F13EE91B6DB8366332CB2C054CC47DE5AA7E* __this, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 ___0_serializer, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC BufferSerializer_1_GetFastBufferWriter_m9C29FD83F1F84F7DB243974892CB6612AE9ACCE9 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 BufferSerializer_1_GetFastBufferReader_mF14C151E60E6525341AD31B18744F2DCC23DE063 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_m0773DBBB39CFDB93D7DE224B29AA3E23DADF8D16 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetworkDeltaPosition_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_mEFF3CFDD8175C997D6164E5198B21F8664987407 (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* __this, BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B ___0_serializer, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeNetworkSerializable_TisNetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9_m86B6020E8E8853ACD5CA58B7EEB3913F7EE11A97 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m6101B238F07953CE18E1F86F2233DEFF3CB93159 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, float* ___0_value, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_mF8864064239A7820146C9482A6E1F7FE22607F81 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_m175DEC7EA748331C16BF1972F3981E933059BE3A (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, uint32_t* ___0_value, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeNetworkSerializable_TisHalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD_mC29BAD249B57B83497C2A1EFAD69D6E2A902F55D (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisHalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02_mAD61C61A65799B59048C11919A5C6FD17115B106 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* ___0_value, ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetworkTransformState_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_m315FE7B6046C0603C6C2F4904F76DDE868D9E59F (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B ___0_serializer, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC BufferSerializer_1_GetFastBufferWriter_m0EDCCFEDDC0A291D14ACA9BB1DA18CD0ABAD9C60 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 BufferSerializer_1_GetFastBufferReader_mBE4915BC31492038A896F4FE19E6A1D815815171 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_m0364BE9DADF6A928C2E671E4712E0E74660342D6 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetworkDeltaPosition_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m30FDAAF063DE71B8F7846DA81B669D88BE18CDBB (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* __this, BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0 ___0_serializer, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeNetworkSerializable_TisNetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9_mB135731E72075A1E8F5F62A67D8A5CC317474852 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m27B1CE4986F8F5797956E336EDF7FF730AB613E4 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, float* ___0_value, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_m5703B125C4DB4384D52002A802AB88FA88E27331 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_m6F6DFB50403FF15EAF7B88A883C1739AE9E6900B (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, uint32_t* ___0_value, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeNetworkSerializable_TisHalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD_m3EAD438E8EC22446E2CAF3F94F16058FB339A67C (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisHalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02_mF16FD9701D269D224C92C0ED1E0D19F34B152CC2 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* ___0_value, ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetworkTransformState_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m1D7D00149B9F8D0C238E26F460829DA7CB811511 (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0 ___0_serializer, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetworkTransformState_NetworkSerialize_TisIl2CppFullySharedGenericAny_mCF668FDFEBE2180BB40C932053267AF2F816687C_fshared (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 ___0_serializer, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR intptr_t MarshalledUnityObject_MarshalNotNull_TisIl2CppSharedGenericObject_mCE897EC9A79983B4B1E6E2C8342452256309044A_gshared_inline (Il2CppSharedGenericObject* ___0_obj, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HashSet_1__ctor_m0823862A6DDE661D7383395095FB6E793F8C2162_gshared (HashSet_1_tBCF0302A9E9E74ECC464F4B0C6A09F22E5114AFD* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool HashSet_1_Add_m7BC8346BAB1CD540AAB8BF8A6471F9803B8E26B1_gshared (HashSet_1_tBCF0302A9E9E74ECC464F4B0C6A09F22E5114AFD* __this, Il2CppSharedGenericObject* ___0_item, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Stack_1_Push_mDE9210C5D1711198B54F42F2F335C67755011949_gshared (Stack_1_t0CA5713F7DD620D4C839FC6F19CEA972026B8212* __this, Il2CppSharedGenericObject* ___0_item, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Il2CppSharedGenericObject* Stack_1_Pop_m3DE7C3332F22E12FFDFE78B3A71F698D96DD2374_gshared (Stack_1_t0CA5713F7DD620D4C839FC6F19CEA972026B8212* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t DynamicArray_1_get_size_m128222BE63C9931B08CD38DF32B858CD1CD4926D_fshared_inline (DynamicArray_1_tFD6392EE4EAA442D167A921C9964FD9C17FDCDE0* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DynamicArray_1_Resize_m97E71E435F74A3E3C7E1BC6E733A0AFB9816550D_gshared (DynamicArray_1_t2A75BEDB4D41FF2FB6EC822B2CFBD037211F784D* __this, int32_t ___0_newSize, bool ___1_keepContent, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Il2CppSharedGenericObject** DynamicArray_1_get_Item_mA2D6D01C2851B649C10AAB4D7F0EB01F2E0596EE_gshared (DynamicArray_1_t2A75BEDB4D41FF2FB6EC822B2CFBD037211F784D* __this, int32_t ___0_index, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_NO_INLINE IL2CPP_METHOD_ATTR Il2CppSharedGenericObject* Activator_CreateInstance_TisIl2CppSharedGenericObject_m4C74D3D65600820EB977E87AD08D24AF782C97C3_gshared (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NativeArray_1_tDB8B8DC66CC8E16ED6D9A8C75D2C1AFC80AC1E18 NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisIl2CppFullySharedGenericStruct_m6920C14D4E38FAB84BD2B5F148CE70DF7F224F52_fshared (void* ___0_dataPointer, int32_t ___1_length, int32_t ___2_allocator, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ReadOnlySpan_1__ctor_mD031F18A4CFBB5CBC861231C3D6E56106D809509_fshared_inline (ReadOnlySpan_1_tC416A5627E04F69CA2947A2A13F0A1DF096CABAC* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ReadOnlySpan_1__ctor_mD692C6AD4A813B80EF4C2C650DA20A01BAB8B900_inline (ReadOnlySpan_1_t7C8438B00110311A3FFF078F848928218D9D79F1* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ReadOnlySpan_1__ctor_m84B3CCED99878FDE74473A0EE7D051C8467D541A_inline (ReadOnlySpan_1_tD1C684B7FBBE6B196C3D9C25D26C14087DDACC42* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ReadOnlySpan_1__ctor_m10EFD956DD5598E0BB4B432705ECA2DC3D21B5CF_inline (ReadOnlySpan_1_t2FC42E74698A85F864327A2F3603A016F223B360* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ReadOnlySpan_1__ctor_m15EED2F0FD0AD432090A6856F982685B71467F81_inline (ReadOnlySpan_1_t7D0A62688D12B6224D58E7D7EB6BBE34C2B5705B* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ReadOnlySpan_1__ctor_mA26404126E9D9DE6BE29D5F9EF6C6BC2422A2D88_inline (ReadOnlySpan_1_t2239736A651E959D4A4360EBC03DFBCFAE1C9DA6* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ReadOnlySpan_1__ctor_m748A11CB59F4600404CFE970131654050E606631_inline (ReadOnlySpan_1_t4A1964D3768FECC83DDD199B546B177020E04377* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Span_1__ctor_m5599DAEC88C08C9797F461E977BF22E14E3C3008_fshared_inline (Span_1_tDEB40BEFA77B5E4BB49B058CD3050EEA4DD36C54* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Span_1__ctor_m8B358C367FCD4C5DF714C69892BD3F238BC4BE78_inline (Span_1_t9F6FBEA217E68146892F6B8BBCE2E2C9E95689A1* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool* UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mFAC64123CDCBD55D7F3EBE960A434127DBAC2DB0_inline (bool* ___0_from, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisDouble_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m29A9863FEB29DD171534C86E92808796F4F4451A (double* ___0_source, bool* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint8_t* UnsafeUtility_As_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m3DC6C8431AF46D3B4AD529D400BD9FD0DC961014_inline (uint8_t* ___0_from, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisDouble_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m8FF415C41F9748700137EB247B2399BE6D3629AC (double* ___0_source, uint8_t* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int16_t* UnsafeUtility_As_TisInt16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_TisInt16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_m79136FE812DC030B796002F8D0127FADB3845447_inline (int16_t* ___0_from, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR GCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC* UnsafeUtility_As_TisIntPtr_t_TisGCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC_mD94F597CB91662C823496DA9FA9A7CF908734A78_inline (intptr_t* ___0_from, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Il2CppFullySharedGenericAny* UnsafeUtilityInternal_As_TisIl2CppFullySharedGenericAny_TisIl2CppFullySharedGenericAny_mE1CA751887466B801BE69083C2B0EA3EDE41FF9B_fshared_inline (Il2CppFullySharedGenericAny* ___0_from, const RuntimeMethod* method) ;

IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void BytePacker_WriteValuePacked_m28A6B72074DC64885C3C9CDD75E9B9F955F8C3C5_inline (FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC ___0_writer, int32_t ___1_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ByteUnpacker_ReadValuePacked_m7096AA51201BA17A76B47364E7021F390E9A6FD6_inline (FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 ___0_reader, int32_t* ___1_value, const RuntimeMethod* method) ;
inline void AnimationState_NetworkSerialize_TisIl2CppFullySharedGenericAny_m760AC204C9E95DFB88C5DA7B9EC8814C6D49A1F5 (AnimationState_t90091AD2757C132602279750EFF7907F066817B0* __this, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 ___0_serializer, const RuntimeMethod* method)
{
	((  void (*) (AnimationState_t90091AD2757C132602279750EFF7907F066817B0*, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10, const RuntimeMethod*))AnimationState_NetworkSerialize_TisIl2CppFullySharedGenericAny_m760AC204C9E95DFB88C5DA7B9EC8814C6D49A1F5_fshared)((AnimationState_t90091AD2757C132602279750EFF7907F066817B0*)__this, ___0_serializer, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m59AF230EB443B685CB322B5AA0898734756EADD7 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, int32_t* ___0_value, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m53224A30FDD9F347134C5F058A4AA1902F046703 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, bool* ___0_value, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AnimationTriggerMessage_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_mB3FE1737DB61D6C43FC1D5DF82F2517258B17F5F (AnimationTriggerMessage_t5E9BAC8B6B7C3A3D79E9448C8C735380FBFC72FF* __this, BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B ___0_serializer, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m77A3B1A6805879DFC74A55FBE9F076C81CF22869 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, int32_t* ___0_value, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m7B4A33CD1D215EDE706B9F3F54F930263A54879F (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, bool* ___0_value, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AnimationTriggerMessage_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m831257AA195AD81E1B8876E6192CE70252D31F1D (AnimationTriggerMessage_t5E9BAC8B6B7C3A3D79E9448C8C735380FBFC72FF* __this, BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0 ___0_serializer, const RuntimeMethod* method) ;
inline void AnimationTriggerMessage_NetworkSerialize_TisIl2CppFullySharedGenericAny_m12CFDF3873F81396A10F13261B1DF4F83D0A99D8 (AnimationTriggerMessage_t5E9BAC8B6B7C3A3D79E9448C8C735380FBFC72FF* __this, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 ___0_serializer, const RuntimeMethod* method)
{
	((  void (*) (AnimationTriggerMessage_t5E9BAC8B6B7C3A3D79E9448C8C735380FBFC72FF*, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10, const RuntimeMethod*))AnimationTriggerMessage_NetworkSerialize_TisIl2CppFullySharedGenericAny_m12CFDF3873F81396A10F13261B1DF4F83D0A99D8_fshared)((AnimationTriggerMessage_t5E9BAC8B6B7C3A3D79E9448C8C735380FBFC72FF*)__this, ___0_serializer, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m1D4559355D8982D0FDFBECB67C3DFD8B5977522F (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** ___0_value, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ParametersUpdateMessage_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_mDAD146156C033575D7A28EE56A00A98731B84A0A (ParametersUpdateMessage_tA77A911264605B5AE8FE181D2A1BA78A4E2B41CC* __this, BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B ___0_serializer, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_mAD89D6AD1671054722C3ECC148291524285C35D8 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** ___0_value, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ParametersUpdateMessage_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m69B6E53197F936BB20E239A5CE6795AE55497DF9 (ParametersUpdateMessage_tA77A911264605B5AE8FE181D2A1BA78A4E2B41CC* __this, BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0 ___0_serializer, const RuntimeMethod* method) ;
inline void ParametersUpdateMessage_NetworkSerialize_TisIl2CppFullySharedGenericAny_mB78A86C8B7A4255E424BE9FEC1CFE27AD6EBA453 (ParametersUpdateMessage_tA77A911264605B5AE8FE181D2A1BA78A4E2B41CC* __this, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 ___0_serializer, const RuntimeMethod* method)
{
	((  void (*) (ParametersUpdateMessage_tA77A911264605B5AE8FE181D2A1BA78A4E2B41CC*, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10, const RuntimeMethod*))ParametersUpdateMessage_NetworkSerialize_TisIl2CppFullySharedGenericAny_mB78A86C8B7A4255E424BE9FEC1CFE27AD6EBA453_fshared)((ParametersUpdateMessage_tA77A911264605B5AE8FE181D2A1BA78A4E2B41CC*)__this, ___0_serializer, method);
}
inline void BufferSerializer_1_SerializeValue_TisMapTypes_tB24369EF24F9A74D2FA0CA938B55392EA305822C_m2AC2341E6BB3C951514A39EFC0EAA7360C82BADB (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, int32_t* ___0_value, ForEnums_tD6A048FB8E80A3A6DC7DE4B6DE48D635362F7511 ___1_unused, const RuntimeMethod* method)
{
	((  void (*) (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B*, int32_t*, ForEnums_tD6A048FB8E80A3A6DC7DE4B6DE48D635362F7511, const RuntimeMethod*))BufferSerializer_1_SerializeValue_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m58D81C281DF1007FE8512D26EBF07BB09459BC28_gshared)(__this, ___0_value, ___1_unused, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool BufferSerializer_1_get_IsReader_m6391807CBC3E99FB5B0C0306A3407B988C01270B (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_mFC3CDB7ADDAFE46729C25BAAACFC409528BD2995 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, String_t** ___0_s, bool ___1_oneByteChars, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool BufferSerializer_1_get_IsWriter_m6978D539067CE30EC81B6491589C7C30A1E16C28 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetworkSceneHandle_IsEmpty_mEB284E9B208574F9149A96A5DCF02E52DD5D3C1B (NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 SceneHandle_get_None_m4E17CDCF9D442196A84BE18E986F65ABA8FA8B87 (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool SceneHandle_op_Inequality_mA715EC25F82CBA38DF43336E584226EEAE7A3223 (SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 ___0_left, SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 ___1_right, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D NetworkSceneHandle_op_Implicit_m4E8B9C02A2029CC121E02E6AA0BC7F7D3F782824 (SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 ___0_handle, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisNetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D_m8291063A935C8DCA24338F6C4EE6E3F14117C1E8 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* ___0_value, ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 NetworkSceneHandle_op_Implicit_m071F9D70086FE159910ABC5BE5358EB76761C589_inline (NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D ___0_handle, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SceneMap_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_m9853256DC4E5A60E8A9D416599B7D6E4153A2AF6 (SceneMap_tD765F13EE91B6DB8366332CB2C054CC47DE5AA7E* __this, BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B ___0_serializer, const RuntimeMethod* method) ;
inline void BufferSerializer_1_SerializeValue_TisMapTypes_tB24369EF24F9A74D2FA0CA938B55392EA305822C_m9BDA7530FCB1F971940081D0F60F9A5118CB418E (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, int32_t* ___0_value, ForEnums_tD6A048FB8E80A3A6DC7DE4B6DE48D635362F7511 ___1_unused, const RuntimeMethod* method)
{
	((  void (*) (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0*, int32_t*, ForEnums_tD6A048FB8E80A3A6DC7DE4B6DE48D635362F7511, const RuntimeMethod*))BufferSerializer_1_SerializeValue_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m2654B874743146008CACD143DFD23C2313A11933_gshared)(__this, ___0_value, ___1_unused, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool BufferSerializer_1_get_IsReader_mBAAFBF1B83961D969792A2CDB52D3EE2B05653DF (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_mB617CF6234422CCCAD113FE97A1D5E18DB802962 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, String_t** ___0_s, bool ___1_oneByteChars, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool BufferSerializer_1_get_IsWriter_mA81CADE3680B019327BD43C92F4743B2140A83EB (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisNetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D_mADBE51CDBAEF491B1ACBE311CC6940C791075273 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* ___0_value, ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SceneMap_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m9A4D0AB395FD9325D6F1E30FC65753F2C6684C21 (SceneMap_tD765F13EE91B6DB8366332CB2C054CC47DE5AA7E* __this, BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0 ___0_serializer, const RuntimeMethod* method) ;
inline void SceneMap_NetworkSerialize_TisIl2CppFullySharedGenericAny_m2DE7C2FEDDE74AF6ADEE717F91A54EFCBBC9C13D (SceneMap_tD765F13EE91B6DB8366332CB2C054CC47DE5AA7E* __this, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 ___0_serializer, const RuntimeMethod* method)
{
	((  void (*) (SceneMap_tD765F13EE91B6DB8366332CB2C054CC47DE5AA7E*, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10, const RuntimeMethod*))SceneMap_NetworkSerialize_TisIl2CppFullySharedGenericAny_m2DE7C2FEDDE74AF6ADEE717F91A54EFCBBC9C13D_fshared)((SceneMap_tD765F13EE91B6DB8366332CB2C054CC47DE5AA7E*)__this, ___0_serializer, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC BufferSerializer_1_GetFastBufferWriter_m9C29FD83F1F84F7DB243974892CB6612AE9ACCE9 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t FastBufferWriter_get_Position_m87642B5268B41B7D15D4E628DF93A5B5776A4B05_inline (FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 BufferSerializer_1_GetFastBufferReader_mF14C151E60E6525341AD31B18744F2DCC23DE063 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t FastBufferReader_get_Position_m6B9DC9ECC9F2D943EA0103248E10AB9B95C8F4CF_inline (FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint32_t FlagStates_GetBitsetRepresentation_m7002081C4C5BD54947BD04940B1FA592C83CEC3B_inline (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BytePacker_WriteValueBitPacked_m50033FEA83560CA7AF9668B3C7352E013D518F11 (FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC ___0_writer, uint32_t ___1_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BytePacker_WriteValueBitPacked_m510F6322BA0F2C85AF9527A7927FF9B03F0AE613 (FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC ___0_writer, int32_t ___1_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ByteUnpacker_ReadValueBitPacked_mACA5F48002EFB41F31DB0F4AAB4936A2E423DCA4 (FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 ___0_reader, uint32_t* ___1_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void FlagStates_SetStateFromBitset_m88B26BC623EA70281C6F7A973DC460786017B638_inline (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* __this, uint32_t ___0_bitset, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ByteUnpacker_ReadValueBitPacked_mC5142499F3BA1F4D8C60EDF335D6C54B0D78C4AC (FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 ___0_reader, int32_t* ___1_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasPositionChange_mF827577ABA451C60526B23885B255D1285B1FBBF_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_UseHalfFloatPrecision_m0513126B8151A8353AF0931D1E792F9E064C7FA8_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasPositionX_mC8E02257F7B924AF10C4E88A21C6DF55264A6451_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void bool3_set_Item_m97B15081414771CC507C55695692865801C588A6 (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* __this, int32_t ___0_index, bool ___1_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasPositionY_mB77D3E22968FCB3B1F946A7F963E6AFABF915D89_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasPositionZ_m3EB043B0EBA833E145F80474615FA82061165C9B_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_IsTeleportingNextFrame_m7139315A1CE849C8DBB503EA4154E6D71582B254_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_m0773DBBB39CFDB93D7DE224B29AA3E23DADF8D16 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___0_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_IsSynchronizing_m99FE076BE4E9D7AB6F7DAF16523F5B72027269EE_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetworkDeltaPosition_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_mEFF3CFDD8175C997D6164E5198B21F8664987407 (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* __this, BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B ___0_serializer, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeNetworkSerializable_TisNetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9_m86B6020E8E8853ACD5CA58B7EEB3913F7EE11A97 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m6101B238F07953CE18E1F86F2233DEFF3CB93159 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, float* ___0_value, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasRotAngleChange_m4D900826D7636E38F55B6BEDBD88A61230FEE50A_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_QuaternionSync_mBB94E4FD11175FD76DDF0EAEB0210E369F28C747_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_mF8864064239A7820146C9482A6E1F7FE22607F81 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* ___0_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_QuaternionCompression_m0473AF4A43B2923E5C2359643E3C7C68DEE6339B_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint32_t QuaternionCompressor_CompressQuaternion_mDFB8E04C1429D8183D314DAEA13E7725C0FADDAD_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* ___0_quaternion, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_m175DEC7EA748331C16BF1972F3981E933059BE3A (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, uint32_t* ___0_value, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void QuaternionCompressor_DecompressQuaternion_mDABA28208E32355842F5BFA792A08813DBE82F51_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* ___0_quaternion, uint32_t ___1_compressed, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void HalfVector4_UpdateFrom_m49F84D6FA68D9025729B9AE5BED74C42FC1C2A4D_inline (HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD* __this, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* ___0_quaternion, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeNetworkSerializable_TisHalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD_mC29BAD249B57B83497C2A1EFAD69D6E2A902F55D (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD* ___0_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 HalfVector4_ToQuaternion_m2A8121C41C193D8B2BE815FE6C741057B4BD85C5_inline (HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasRotAngleX_m2017FDEB7C6355F80DCAD0258AA5486D6FBDC816_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasRotAngleY_m1D53E40810F158FDFEEAC32A1487E63ABC5CB040_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasRotAngleZ_m5B23DA8ED870129BF35C9A82B7776605C248DE04_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HalfVector3_Set_m442C051B289196D68C7B0C6C38ABBA71EADDADEA (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* __this, float ___0_x, float ___1_y, float ___2_z, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisHalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02_mAD61C61A65799B59048C11919A5C6FD17115B106 (BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B* __this, HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* ___0_value, ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 HalfVector3_ToVector3_m0D9B03E9618FA457A3A527E30AA765EB4093D0D1_inline (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasScaleChange_mD5FBA90EF892DC24F087B409A4A4F04178E955F7_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasScaleX_m82B5E6E8FD2A17E31F8B4179124227E34D190756_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasScaleY_mC709C18060AFD0D5944B749FAE96A82F8B078821_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasScaleZ_m812D411158FC2B56DFE0BC3EA77A999220F52FD8_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, int32_t ___0_index, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void NetworkTransformState_set_LastSerializedSize_m495ABA7CDD6AC0B7900EF02669F839F002427BF2_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, int32_t ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetworkTransformState_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_m315FE7B6046C0603C6C2F4904F76DDE868D9E59F (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B ___0_serializer, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC BufferSerializer_1_GetFastBufferWriter_m0EDCCFEDDC0A291D14ACA9BB1DA18CD0ABAD9C60 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 BufferSerializer_1_GetFastBufferReader_mBE4915BC31492038A896F4FE19E6A1D815815171 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_m0364BE9DADF6A928C2E671E4712E0E74660342D6 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetworkDeltaPosition_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m30FDAAF063DE71B8F7846DA81B669D88BE18CDBB (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* __this, BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0 ___0_serializer, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeNetworkSerializable_TisNetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9_mB135731E72075A1E8F5F62A67D8A5CC317474852 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m27B1CE4986F8F5797956E336EDF7FF730AB613E4 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, float* ___0_value, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_m5703B125C4DB4384D52002A802AB88FA88E27331 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_m6F6DFB50403FF15EAF7B88A883C1739AE9E6900B (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, uint32_t* ___0_value, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeNetworkSerializable_TisHalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD_m3EAD438E8EC22446E2CAF3F94F16058FB339A67C (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BufferSerializer_1_SerializeValue_TisHalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02_mF16FD9701D269D224C92C0ED1E0D19F34B152CC2 (BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0* __this, HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* ___0_value, ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 ___1_unused, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetworkTransformState_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m1D7D00149B9F8D0C238E26F460829DA7CB811511 (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0 ___0_serializer, const RuntimeMethod* method) ;
inline void NetworkTransformState_NetworkSerialize_TisIl2CppFullySharedGenericAny_mCF668FDFEBE2180BB40C932053267AF2F816687C (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 ___0_serializer, const RuntimeMethod* method)
{
	((  void (*) (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED*, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10, const RuntimeMethod*))NetworkTransformState_NetworkSerialize_TisIl2CppFullySharedGenericAny_mCF668FDFEBE2180BB40C932053267AF2F816687C_fshared)((NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED*)__this, ___0_serializer, method);
}
inline intptr_t MarshalledUnityObject_MarshalNotNull_TisIl2CppSharedGenericObject_mCE897EC9A79983B4B1E6E2C8342452256309044A_inline (Il2CppSharedGenericObject* ___0_obj, const RuntimeMethod* method)
{
	return ((  intptr_t (*) (Il2CppSharedGenericObject*, const RuntimeMethod*))MarshalledUnityObject_MarshalNotNull_TisIl2CppSharedGenericObject_mCE897EC9A79983B4B1E6E2C8342452256309044A_gshared_inline)(___0_obj, method);
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool IntPtr_op_Equality_m7D9CDCDE9DC2A0C2C614633F4921E90187FAB271_inline (intptr_t ___0_value1, intptr_t ___1_value2, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR GCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC MarshalledUnityObject_FromIntPtrUnsafe_m1C5AE0FB7CD1978A8387B0081DB909BAAC2324C3_inline (intptr_t ___0_gcHandle, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* GCHandle_get_Target_m481F9508DA5E384D33CD1F4450060DC56BBD4CD5_inline (GCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC* __this, const RuntimeMethod* method) ;
inline void HashSet_1__ctor_mC6742D4B2D1A12A042DB56C25EEF951C4BAC992B (HashSet_1_t068F5201D923072F46716204841D21328FE6218D* __this, const RuntimeMethod* method)
{
	((  void (*) (HashSet_1_t068F5201D923072F46716204841D21328FE6218D*, const RuntimeMethod*))HashSet_1__ctor_m0823862A6DDE661D7383395095FB6E793F8C2162_gshared)(__this, method);
}
inline bool HashSet_1_Add_m9B1803FBD20D89F056AD75F1B6B0E1F5D5CF4F69 (HashSet_1_t068F5201D923072F46716204841D21328FE6218D* __this, ParameterExpression_tE8D3A1137422F75D256CBB200EDC82820F240110* ___0_item, const RuntimeMethod* method)
{
	return ((  bool (*) (HashSet_1_t068F5201D923072F46716204841D21328FE6218D*, ParameterExpression_tE8D3A1137422F75D256CBB200EDC82820F240110*, const RuntimeMethod*))HashSet_1_Add_m7BC8346BAB1CD540AAB8BF8A6471F9803B8E26B1_gshared)(__this, ___0_item, method);
}
inline void Stack_1_Push_m7705C6FDAFECD165E7E24091F066CB47F323E6CE (Stack_1_tC4810ACEE7FD00840B5CB4333A83E2E1553CAD26* __this, HashSet_1_t068F5201D923072F46716204841D21328FE6218D* ___0_item, const RuntimeMethod* method)
{
	((  void (*) (Stack_1_tC4810ACEE7FD00840B5CB4333A83E2E1553CAD26*, HashSet_1_t068F5201D923072F46716204841D21328FE6218D*, const RuntimeMethod*))Stack_1_Push_mDE9210C5D1711198B54F42F2F335C67755011949_gshared)(__this, ___0_item, method);
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785* LambdaExpression_get_Body_m161E156442547AE8A6837C5AE065BD93345451DE_inline (LambdaExpression_tD26FB6AEAD01B2EBB668CDEAFAAFA4948697300E* __this, const RuntimeMethod* method) ;
inline HashSet_1_t068F5201D923072F46716204841D21328FE6218D* Stack_1_Pop_mBE2B08F95D18382A9C64D99E1065B899EB75E6E5 (Stack_1_tC4810ACEE7FD00840B5CB4333A83E2E1553CAD26* __this, const RuntimeMethod* method)
{
	return ((  HashSet_1_t068F5201D923072F46716204841D21328FE6218D* (*) (Stack_1_tC4810ACEE7FD00840B5CB4333A83E2E1553CAD26*, const RuntimeMethod*))Stack_1_Pop_m3DE7C3332F22E12FFDFE78B3A71F698D96DD2374_gshared)(__this, method);
}
inline int32_t DynamicArray_1_get_size_m0C78CDCD1FF6A1256C3382649AF82DE707BB6C16_inline (DynamicArray_1_tE5A650707ED617C8B11E4B6F29F3207E02383467* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (DynamicArray_1_tE5A650707ED617C8B11E4B6F29F3207E02383467*, const RuntimeMethod*))DynamicArray_1_get_size_m128222BE63C9931B08CD38DF32B858CD1CD4926D_fshared_inline)(__this, method);
}
inline void DynamicArray_1_Resize_m71330886D4896ECE91617DB09FAF262B0E24B00B (DynamicArray_1_tE5A650707ED617C8B11E4B6F29F3207E02383467* __this, int32_t ___0_newSize, bool ___1_keepContent, const RuntimeMethod* method)
{
	((  void (*) (DynamicArray_1_tE5A650707ED617C8B11E4B6F29F3207E02383467*, int32_t, bool, const RuntimeMethod*))DynamicArray_1_Resize_m97E71E435F74A3E3C7E1BC6E733A0AFB9816550D_gshared)(__this, ___0_newSize, ___1_keepContent, method);
}
inline IRenderGraphResource_t8C49F0158EDB9571FA4BDAF754E09A32E535C021** DynamicArray_1_get_Item_mEFCD58DBBE282DE955FAEF10ECACCF41D9E04869 (DynamicArray_1_tE5A650707ED617C8B11E4B6F29F3207E02383467* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	return ((  IRenderGraphResource_t8C49F0158EDB9571FA4BDAF754E09A32E535C021** (*) (DynamicArray_1_tE5A650707ED617C8B11E4B6F29F3207E02383467*, int32_t, const RuntimeMethod*))DynamicArray_1_get_Item_mA2D6D01C2851B649C10AAB4D7F0EB01F2E0596EE_gshared)(__this, ___0_index, method);
}
inline Il2CppSharedGenericObject* Activator_CreateInstance_TisIl2CppSharedGenericObject_m4C74D3D65600820EB977E87AD08D24AF782C97C3 (const RuntimeMethod* method)
{
	return ((  Il2CppSharedGenericObject* (*) (const RuntimeMethod*))Activator_CreateInstance_TisIl2CppSharedGenericObject_m4C74D3D65600820EB977E87AD08D24AF782C97C3_gshared)(method);
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void* IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline (intptr_t* __this, const RuntimeMethod* method) ;
inline NativeArray_1_t7D2E0867BA2C51E53A2DA86335020B175E7CDC86 NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisTransformWriteTween_t86FB859350EF146AC5D9CB4CA8196377B714E2B7_mCAB0D1991E3CA4A5F2B29699805088ED767C85BF (void* ___0_dataPointer, int32_t ___1_length, int32_t ___2_allocator, const RuntimeMethod* method)
{
	return ((  NativeArray_1_t7D2E0867BA2C51E53A2DA86335020B175E7CDC86 (*) (void*, int32_t, int32_t, const RuntimeMethod*))NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisIl2CppFullySharedGenericStruct_m6920C14D4E38FAB84BD2B5F148CE70DF7F224F52_fshared)(___0_dataPointer, ___1_length, ___2_allocator, method);
}
inline NativeArray_1_tD433A29296E2B6926BA29A86B35FEEA6C63C8C68 NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisTransformChangeEvent_tAE5E62820ECA07C3DA656E95A0426D046DBF1A70_m9FF20AB277A63B6352D86FBE981963C274C1F6CA (void* ___0_dataPointer, int32_t ___1_length, int32_t ___2_allocator, const RuntimeMethod* method)
{
	return ((  NativeArray_1_tD433A29296E2B6926BA29A86B35FEEA6C63C8C68 (*) (void*, int32_t, int32_t, const RuntimeMethod*))NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisIl2CppFullySharedGenericStruct_m6920C14D4E38FAB84BD2B5F148CE70DF7F224F52_fshared)(___0_dataPointer, ___1_length, ___2_allocator, method);
}
inline NativeArray_1_tAE73165FE666BFCBFB4CA0B72FFA351ED1872602 NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisCapsuleGeometryElement_t834B66F28B944AA313AB50C9C1343105C15B591E_m9060EF20AD31BDDBF8E6A4D61F091D03B101F9E4 (void* ___0_dataPointer, int32_t ___1_length, int32_t ___2_allocator, const RuntimeMethod* method)
{
	return ((  NativeArray_1_tAE73165FE666BFCBFB4CA0B72FFA351ED1872602 (*) (void*, int32_t, int32_t, const RuntimeMethod*))NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisIl2CppFullySharedGenericStruct_m6920C14D4E38FAB84BD2B5F148CE70DF7F224F52_fshared)(___0_dataPointer, ___1_length, ___2_allocator, method);
}
inline NativeArray_1_tBA0BC79DB482632B1DB9D7FF91357CE99B4C73CF NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisCircleGeometryElement_t9BD9AA0533C99AD620F9AED6458DFAE45B09B2B1_mEFA16883E3A65609AE169271BE4C8883BFC02D22 (void* ___0_dataPointer, int32_t ___1_length, int32_t ___2_allocator, const RuntimeMethod* method)
{
	return ((  NativeArray_1_tBA0BC79DB482632B1DB9D7FF91357CE99B4C73CF (*) (void*, int32_t, int32_t, const RuntimeMethod*))NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisIl2CppFullySharedGenericStruct_m6920C14D4E38FAB84BD2B5F148CE70DF7F224F52_fshared)(___0_dataPointer, ___1_length, ___2_allocator, method);
}
inline NativeArray_1_t2EDCD6FB85206C53A92873BFCBE46ACD9462C683 NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisLineElement_t012671A3568902C51830B75D1F5DB18B390F8454_m4A66A3B213055D7307CFE8FEFA301961ABB4D1C8 (void* ___0_dataPointer, int32_t ___1_length, int32_t ___2_allocator, const RuntimeMethod* method)
{
	return ((  NativeArray_1_t2EDCD6FB85206C53A92873BFCBE46ACD9462C683 (*) (void*, int32_t, int32_t, const RuntimeMethod*))NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisIl2CppFullySharedGenericStruct_m6920C14D4E38FAB84BD2B5F148CE70DF7F224F52_fshared)(___0_dataPointer, ___1_length, ___2_allocator, method);
}
inline NativeArray_1_tE9E9E78E659CC7A96EFD37D8824AEE58DE412CA8 NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisPointElement_t5B29DB72B622AE3FF0CFB790DF18EC71970C66A0_m5F6104B7BABDD0AAEFC152E74ED645A50510E900 (void* ___0_dataPointer, int32_t ___1_length, int32_t ___2_allocator, const RuntimeMethod* method)
{
	return ((  NativeArray_1_tE9E9E78E659CC7A96EFD37D8824AEE58DE412CA8 (*) (void*, int32_t, int32_t, const RuntimeMethod*))NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisIl2CppFullySharedGenericStruct_m6920C14D4E38FAB84BD2B5F148CE70DF7F224F52_fshared)(___0_dataPointer, ___1_length, ___2_allocator, method);
}
inline NativeArray_1_tA05A93824C515FF087043027C088AD9C5375BB1D NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisPolygonGeometryElement_t4D6D06844AC5A1A51A7DD2F3BBA661FF1C906A57_mBFD05CEEFBE002B3A028DCB2B994626108D1DE63 (void* ___0_dataPointer, int32_t ___1_length, int32_t ___2_allocator, const RuntimeMethod* method)
{
	return ((  NativeArray_1_tA05A93824C515FF087043027C088AD9C5375BB1D (*) (void*, int32_t, int32_t, const RuntimeMethod*))NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisIl2CppFullySharedGenericStruct_m6920C14D4E38FAB84BD2B5F148CE70DF7F224F52_fshared)(___0_dataPointer, ___1_length, ___2_allocator, method);
}
inline void ReadOnlySpan_1__ctor_m7456175BCB588AEE6932DC60D543FFA702ED3AB8_inline (ReadOnlySpan_1_tE8C37D9A05FCAB953169AFFE8A0ABCA809781E25* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method)
{
	((  void (*) (ReadOnlySpan_1_tE8C37D9A05FCAB953169AFFE8A0ABCA809781E25*, void*, int32_t, const RuntimeMethod*))ReadOnlySpan_1__ctor_mD031F18A4CFBB5CBC861231C3D6E56106D809509_fshared_inline)(__this, ___0_pointer, ___1_length, method);
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ReadOnlySpan_1__ctor_mD692C6AD4A813B80EF4C2C650DA20A01BAB8B900_inline (ReadOnlySpan_1_t7C8438B00110311A3FFF078F848928218D9D79F1* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ReadOnlySpan_1__ctor_m84B3CCED99878FDE74473A0EE7D051C8467D541A_inline (ReadOnlySpan_1_tD1C684B7FBBE6B196C3D9C25D26C14087DDACC42* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ReadOnlySpan_1__ctor_m10EFD956DD5598E0BB4B432705ECA2DC3D21B5CF_inline (ReadOnlySpan_1_t2FC42E74698A85F864327A2F3603A016F223B360* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ReadOnlySpan_1__ctor_m15EED2F0FD0AD432090A6856F982685B71467F81_inline (ReadOnlySpan_1_t7D0A62688D12B6224D58E7D7EB6BBE34C2B5705B* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ReadOnlySpan_1__ctor_mA26404126E9D9DE6BE29D5F9EF6C6BC2422A2D88_inline (ReadOnlySpan_1_t2239736A651E959D4A4360EBC03DFBCFAE1C9DA6* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ReadOnlySpan_1__ctor_m748A11CB59F4600404CFE970131654050E606631_inline (ReadOnlySpan_1_t4A1964D3768FECC83DDD199B546B177020E04377* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) ;
inline void Span_1__ctor_m2E922F7D304FD1EC1A39BA2A433FAD54064AE45F_inline (Span_1_t3EBD12B39F51F09620FC7421B894677E0D26E0AD* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method)
{
	((  void (*) (Span_1_t3EBD12B39F51F09620FC7421B894677E0D26E0AD*, void*, int32_t, const RuntimeMethod*))Span_1__ctor_m5599DAEC88C08C9797F461E977BF22E14E3C3008_fshared_inline)(__this, ___0_pointer, ___1_length, method);
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Span_1__ctor_m8B358C367FCD4C5DF714C69892BD3F238BC4BE78_inline (Span_1_t9F6FBEA217E68146892F6B8BBCE2E2C9E95689A1* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool* UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mFAC64123CDCBD55D7F3EBE960A434127DBAC2DB0_inline (bool* ___0_from, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Boolean_TryParse_m417053B6E8D3724D0EED9E87C90D143622158352 (String_t* ___0_value, bool* ___1_result, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Double_TryParse_m60AD55BC181D70F661BC2A2294E66B5466C3C018 (String_t* ___0_s, double* ___1_result, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisDouble_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m29A9863FEB29DD171534C86E92808796F4F4451A (double* ___0_source, bool* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint8_t* UnsafeUtility_As_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m3DC6C8431AF46D3B4AD529D400BD9FD0DC961014_inline (uint8_t* ___0_from, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Byte_TryParse_mB1716E3B6714F20DF6C1FEDDC4A76AA78D5EA87B (String_t* ___0_s, uint8_t* ___1_result, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisDouble_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m8FF415C41F9748700137EB247B2399BE6D3629AC (double* ___0_source, uint8_t* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int16_t* UnsafeUtility_As_TisInt16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_TisInt16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_m79136FE812DC030B796002F8D0127FADB3845447_inline (int16_t* ___0_from, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void FlagStates_SetHasPosition_mE51FE437505C4A3EDDEAE595CDAE797026BF6A11_inline (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* __this, int32_t ___0_axis, bool ___1_changed, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void FlagStates_SetHasRotation_mD915333F46992653C0BB3B7B5795633C2FC44878_inline (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* __this, int32_t ___0_axis, bool ___1_changed, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void FlagStates_SetHasScale_m4CA0C4FA4015849D5D5EC76C831DF7EC08A023F3_inline (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* __this, int32_t ___0_axis, bool ___1_changed, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Quaternion_get_Item_m0B886A8EF3417F3309FB0C681A67A4150B7AA739_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* __this, int32_t ___0_index, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_Max_m870B77F6A5225EC21D9778043F987B9B17D08F6B_inline (SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* ___0_values, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Quaternion_set_Item_mFEF628DD58AC71A1E712A6F3F9642D5DA00675CE_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* __this, int32_t ___0_index, float ___1_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 math_half_mF2B3098B2CDE13073D12FE17D4C55A7EF032C6C7_inline (float ___0_v, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR half4_t04B1BC17C3559EC70A5CA2394C7C41B480EA83D8 math_half4_m377DDE973EE37D2127BA2577A2BCB56884A18E83_inline (half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___0_x, half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___1_y, half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___2_z, half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___3_w, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float4_t545A994996126766890C1F28B43EA823F2410190 float4_op_Implicit_mFC36DB25B838CA0D0D0BED5E4D89B1BE75F8212A_inline (half4_t04B1BC17C3559EC70A5CA2394C7C41B480EA83D8 ___0_v, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR quaternion_t9C8C2916B7359C174B215BBB41F290ABCBEA8AEA math_quaternion_mE62A8FC9087230BEA736EDFFF8E08B49A3E1BEC4_inline (float4_t545A994996126766890C1F28B43EA823F2410190 ___0_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_op_Implicit_m89F4373AD134797808033DCACE56E43E7829CF1E_inline (quaternion_t9C8C2916B7359C174B215BBB41F290ABCBEA8AEA ___0_q, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_zero_m0C1249C3F25B1C70EAD3CC8B31259975A457AE39_inline (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float3_t7600B73F092B37F484B12910A5269F30C778D31E math_float3_mBC35F669739DF837407D396F2219211EC69F513A_inline (half3_tAC3065568DE0CD35A46DE11D367236E8FB7BEA07 ___0_v, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Implicit_m67D7F2AD018B7F0B44E10CF164D63A4FB32E6B7D_inline (float3_t7600B73F092B37F484B12910A5269F30C778D31E ___0_v, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool bool3_get_Item_mFE78E2B8E00D439EFDAB96EFD34486010C0EAECB (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* __this, int32_t ___0_index, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector3_set_Item_m79136861DEC5862CE7EC20AB3B0EF10A3957CEC3_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, int32_t ___0_index, float ___1_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IndexOutOfRangeException__ctor_mFD06819F05B815BE2D6E826D4E04F4C449D0A425 (IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82* __this, String_t* ___0_message, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR GCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC* UnsafeUtility_As_TisIntPtr_t_TisGCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC_mD94F597CB91662C823496DA9FA9A7CF908734A78_inline (intptr_t* ___0_from, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool GCHandle_get_IsAllocated_m241908103D8D867E11CCAB73C918729825E86843_inline (GCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162 (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* __this, String_t* ___0_message, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool GCHandle_CanDereferenceHandle_mAAAC42D1268CEF3FDD040A3D1574773D08140579_inline (intptr_t ___0_handle, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* GCHandle_GetRef_mAC7E58E62417209DC41C99F66BA70F0C3AA18DA8_inline (intptr_t ___0_handle, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* GCHandle_GetTarget_mE0AF851834410E2AEA6285B2497751570236C794 (intptr_t ___0_handle, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Type_t* Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57 (RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B ___0_handle, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ThrowHelper_ThrowInvalidTypeWithPointersNotSupported_m5707DE408588F6EAC3FC7D10F9520308CF8C8CCF (Type_t* ___0_targetType, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ThrowHelper_ThrowArgumentOutOfRangeException_mD7D90276EDCDF9394A8EA635923E3B48BB71BD56 (const RuntimeMethod* method) ;
inline bool* UnsafeUtilityInternal_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mE3D9B5B2C16912294630A6DAD8928B960B7544E6_inline (bool* ___0_from, const RuntimeMethod* method)
{
	return ((  bool* (*) (bool*, const RuntimeMethod*))UnsafeUtilityInternal_As_TisIl2CppFullySharedGenericAny_TisIl2CppFullySharedGenericAny_mE1CA751887466B801BE69083C2B0EA3EDE41FF9B_fshared_inline)(___0_from, method);
}
inline uint8_t* UnsafeUtilityInternal_As_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m5A66C1A526E263EC6778FF3879A6E62C618542C4_inline (uint8_t* ___0_from, const RuntimeMethod* method)
{
	return ((  uint8_t* (*) (uint8_t*, const RuntimeMethod*))UnsafeUtilityInternal_As_TisIl2CppFullySharedGenericAny_TisIl2CppFullySharedGenericAny_mE1CA751887466B801BE69083C2B0EA3EDE41FF9B_fshared_inline)(___0_from, method);
}
inline int16_t* UnsafeUtilityInternal_As_TisInt16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_TisInt16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_mD165D6F44825CD0E42C9C1F6248DB1E67976F9C2_inline (int16_t* ___0_from, const RuntimeMethod* method)
{
	return ((  int16_t* (*) (int16_t*, const RuntimeMethod*))UnsafeUtilityInternal_As_TisIl2CppFullySharedGenericAny_TisIl2CppFullySharedGenericAny_mE1CA751887466B801BE69083C2B0EA3EDE41FF9B_fshared_inline)(___0_from, method);
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void half__ctor_m0A0FDAC33D58C3C0E0BB517078C2EAA71E0C30B1_inline (half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579* __this, float ___0_v, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void half4__ctor_m30972A6184726B0D0E0C1506DD656F8694369B54_inline (half4_t04B1BC17C3559EC70A5CA2394C7C41B480EA83D8* __this, half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___0_x, half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___1_y, half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___2_z, half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___3_w, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void float4__ctor_m33E515D88B7B4CBE94B4DAD00A8197C42E44A52D_inline (float4_t545A994996126766890C1F28B43EA823F2410190* __this, half4_t04B1BC17C3559EC70A5CA2394C7C41B480EA83D8 ___0_v, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void quaternion__ctor_m83A4AD6960040C90D6911B0F3AD54CE54DC5AF90_inline (quaternion_t9C8C2916B7359C174B215BBB41F290ABCBEA8AEA* __this, float4_t545A994996126766890C1F28B43EA823F2410190 ___0_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Quaternion__ctor_m868FD60AA65DD5A8AC0C5DEB0608381A8D85FCD8_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* __this, float ___0_x, float ___1_y, float ___2_z, float ___3_w, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void float3__ctor_mF5C4C7146A9B4CBA037E080878C7D0EC10007700_inline (float3_t7600B73F092B37F484B12910A5269F30C778D31E* __this, half3_tAC3065568DE0CD35A46DE11D367236E8FB7BEA07 ___0_v, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, float ___0_x, float ___1_y, float ___2_z, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool IntPtr_op_Inequality_m90EFC9C4CAD9A33E309F2DDF98EE4E1DD253637B_inline (intptr_t ___0_value1, intptr_t ___1_value2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void* IntPtr_op_Explicit_m2728CBA081E79B97DDCF1D4FAD77B309CA1E94BF (intptr_t ___0_value, const RuntimeMethod* method) ;
inline GCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC* UnsafeUtilityInternal_As_TisIntPtr_t_TisGCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC_mD43127D5F7AA6EB4B52E5C30BA53F29843E9E9A2_inline (intptr_t* ___0_from, const RuntimeMethod* method)
{
	return ((  GCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC* (*) (intptr_t*, const RuntimeMethod*))UnsafeUtilityInternal_As_TisIl2CppFullySharedGenericAny_TisIl2CppFullySharedGenericAny_mE1CA751887466B801BE69083C2B0EA3EDE41FF9B_fshared_inline)(___0_from, method);
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint32_t math_f32tof16_mE56D11292C9F7B0C4A14A77AB907C3EC7D571251_inline (float ___0_x, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float half_op_Implicit_m612FDBFDC8E65B79692FC9C0EFE65583E55C6F60_inline (half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___0_d, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint32_t math_asuint_mF26E6B0D25FD1C079FB93E913E339218F2D3B971_inline (float ___0_x, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float math_asfloat_mE332F9C6D56AA099930259ECE729FC5EC8FD2ED8_inline (uint32_t ___0_x, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float math_min_m6AF1FAD0C7D0231E06EB29D9CDB7B19AB11E7C21_inline (float ___0_x, float ___1_y, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint32_t math_select_mED0B241C12084CE6A281C094820E7FCF0233448C_inline (uint32_t ___0_falseValue, uint32_t ___1_trueValue, bool ___2_test, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float math_f16tof32_m3893A7053FE430E3216E25A97E9E9CFF5ABF650D_inline (uint32_t ___0_x, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Single_IsNaN_mFE637F6ECA9F7697CE8EFF56427858F4C5EDF75D_inline (float ___0_f, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t BitConverter_SingleToInt32Bits_mC760C7CFC89725E3CF68DC45BE3A9A42A7E7DA73_inline (float ___0_value, const RuntimeMethod* method) ;
// Method Definition Index: 70237
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AnimationState_NetworkSerialize_TisIl2CppFullySharedGenericAny_m760AC204C9E95DFB88C5DA7B9EC8814C6D49A1F5_fshared (AnimationState_t90091AD2757C132602279750EFF7907F066817B0* __this, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 ___0_serializer, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	//<source_info:<no-source>:1>
	FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC V_0;
	memset((&V_0), 0, sizeof(V_0));
	FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 V_1;
	memset((&V_1), 0, sizeof(V_1));
	ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 V_2;
	memset((&V_2), 0, sizeof(V_2));
	{
		bool L_0;
		L_0 = ((  bool (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 1)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, il2cpp_rgctx_method(method->rgctx_data, 1));
		if (!L_0)
		{
			goto IL_0081;
		}
	}
	{
		FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC L_1;
		L_1 = ((  FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 2)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, il2cpp_rgctx_method(method->rgctx_data, 2));
		V_0 = L_1;
		__this->___m_StateFlags = (uint8_t)0;
		bool L_2 = __this->___Transition;
		if (!L_2)
		{
			goto IL_002f;
		}
	}
	{
		uint8_t L_3 = __this->___m_StateFlags;
		uint8_t L_4 = (il2cpp_codegen_conv<uint8_t,int32_t,int32_t,false,false>(((int32_t)((int32_t)L_3|1)),NULL));
		__this->___m_StateFlags = L_4;
	}

IL_002f:
	{
		bool L_5 = __this->___CrossFade;
		if (!L_5)
		{
			goto IL_0046;
		}
	}
	{
		uint8_t L_6 = __this->___m_StateFlags;
		uint8_t L_7 = (il2cpp_codegen_conv<uint8_t,int32_t,int32_t,false,false>(((int32_t)((int32_t)L_6|2)),NULL));
		__this->___m_StateFlags = L_7;
	}

IL_0046:
	{
		uint8_t* L_8 = (uint8_t*)(&__this->___m_StateFlags);
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, uint8_t*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 3)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_8, il2cpp_rgctx_method(method->rgctx_data, 3));
		FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC L_9 = V_0;
		int32_t L_10 = __this->___StateHash;
		BytePacker_WriteValuePacked_m28A6B72074DC64885C3C9CDD75E9B9F955F8C3C5_inline(L_9, L_10, NULL);
		FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC L_11 = V_0;
		int32_t L_12 = __this->___Layer;
		BytePacker_WriteValuePacked_m28A6B72074DC64885C3C9CDD75E9B9F955F8C3C5_inline(L_11, L_12, NULL);
		bool L_13 = __this->___Transition;
		if (!L_13)
		{
			goto IL_00e4;
		}
	}
	{
		FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC L_14 = V_0;
		int32_t L_15 = __this->___DestinationStateHash;
		BytePacker_WriteValuePacked_m28A6B72074DC64885C3C9CDD75E9B9F955F8C3C5_inline(L_14, L_15, NULL);
		goto IL_00e4;
	}

IL_0081:
	{
		FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 L_16;
		L_16 = ((  FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 4)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, il2cpp_rgctx_method(method->rgctx_data, 4));
		V_1 = L_16;
		uint8_t* L_17 = (uint8_t*)(&__this->___m_StateFlags);
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, uint8_t*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 3)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_17, il2cpp_rgctx_method(method->rgctx_data, 3));
		uint8_t L_18 = __this->___m_StateFlags;
		__this->___Transition = (bool)((((int32_t)((int32_t)((int32_t)L_18&1))) == ((int32_t)1))? 1 : 0);
		uint8_t L_19 = __this->___m_StateFlags;
		__this->___CrossFade = (bool)((((int32_t)((int32_t)((int32_t)L_19&2))) == ((int32_t)2))? 1 : 0);
		FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 L_20 = V_1;
		int32_t* L_21 = (int32_t*)(&__this->___StateHash);
		ByteUnpacker_ReadValuePacked_m7096AA51201BA17A76B47364E7021F390E9A6FD6_inline(L_20, L_21, NULL);
		FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 L_22 = V_1;
		int32_t* L_23 = (int32_t*)(&__this->___Layer);
		ByteUnpacker_ReadValuePacked_m7096AA51201BA17A76B47364E7021F390E9A6FD6_inline(L_22, L_23, NULL);
		bool L_24 = __this->___Transition;
		if (!L_24)
		{
			goto IL_00e4;
		}
	}
	{
		FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 L_25 = V_1;
		int32_t* L_26 = (int32_t*)(&__this->___DestinationStateHash);
		ByteUnpacker_ReadValuePacked_m7096AA51201BA17A76B47364E7021F390E9A6FD6_inline(L_25, L_26, NULL);
	}

IL_00e4:
	{
		float* L_27 = (float*)(&__this->___NormalizedTime);
		il2cpp_codegen_initobj((&V_2), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_28 = V_2;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, float*, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 5)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_27, L_28, il2cpp_rgctx_method(method->rgctx_data, 5));
		float* L_29 = (float*)(&__this->___Weight);
		il2cpp_codegen_initobj((&V_2), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_30 = V_2;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, float*, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 5)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_29, L_30, il2cpp_rgctx_method(method->rgctx_data, 5));
		bool L_31 = __this->___CrossFade;
		if (!L_31)
		{
			goto IL_012e;
		}
	}
	{
		float* L_32 = (float*)(&__this->___Duration);
		il2cpp_codegen_initobj((&V_2), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_33 = V_2;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, float*, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 5)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_32, L_33, il2cpp_rgctx_method(method->rgctx_data, 5));
	}

IL_012e:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void AnimationState_NetworkSerialize_TisIl2CppFullySharedGenericAny_m760AC204C9E95DFB88C5DA7B9EC8814C6D49A1F5_AdjustorThunk (RuntimeObject* __this, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 ___0_serializer, const RuntimeMethod* method)
{
	AnimationState_t90091AD2757C132602279750EFF7907F066817B0* _thisAdjusted;
	_thisAdjusted = il2cpp_codegen_get_raw_data<AnimationState_t90091AD2757C132602279750EFF7907F066817B0>(__this);
	AnimationState_NetworkSerialize_TisIl2CppFullySharedGenericAny_m760AC204C9E95DFB88C5DA7B9EC8814C6D49A1F5(_thisAdjusted, ___0_serializer, method);
}
// Method Definition Index: 70240
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AnimationTriggerMessage_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_mB3FE1737DB61D6C43FC1D5DF82F2517258B17F5F (AnimationTriggerMessage_t5E9BAC8B6B7C3A3D79E9448C8C735380FBFC72FF* __this, BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B ___0_serializer, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		int32_t* L_0 = (int32_t*)(&__this->___Hash);
		il2cpp_codegen_initobj((&V_0), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_1 = V_0;
		BufferSerializer_1_SerializeValue_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m59AF230EB443B685CB322B5AA0898734756EADD7((&___0_serializer), L_0, L_1, NULL);
		bool* L_2 = (bool*)(&__this->___IsTriggerSet);
		il2cpp_codegen_initobj((&V_0), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_3 = V_0;
		BufferSerializer_1_SerializeValue_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m53224A30FDD9F347134C5F058A4AA1902F046703((&___0_serializer), L_2, L_3, NULL);
		return;
	}
}
IL2CPP_EXTERN_C  void AnimationTriggerMessage_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_mB3FE1737DB61D6C43FC1D5DF82F2517258B17F5F_AdjustorThunk (RuntimeObject* __this, BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B ___0_serializer, const RuntimeMethod* method)
{
	AnimationTriggerMessage_t5E9BAC8B6B7C3A3D79E9448C8C735380FBFC72FF* _thisAdjusted;
	_thisAdjusted = il2cpp_codegen_get_raw_data<AnimationTriggerMessage_t5E9BAC8B6B7C3A3D79E9448C8C735380FBFC72FF>(__this);
	AnimationTriggerMessage_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_mB3FE1737DB61D6C43FC1D5DF82F2517258B17F5F(_thisAdjusted, ___0_serializer, method);
}
// Method Definition Index: 70240
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AnimationTriggerMessage_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m831257AA195AD81E1B8876E6192CE70252D31F1D (AnimationTriggerMessage_t5E9BAC8B6B7C3A3D79E9448C8C735380FBFC72FF* __this, BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0 ___0_serializer, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		int32_t* L_0 = (int32_t*)(&__this->___Hash);
		il2cpp_codegen_initobj((&V_0), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_1 = V_0;
		BufferSerializer_1_SerializeValue_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m77A3B1A6805879DFC74A55FBE9F076C81CF22869((&___0_serializer), L_0, L_1, NULL);
		bool* L_2 = (bool*)(&__this->___IsTriggerSet);
		il2cpp_codegen_initobj((&V_0), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_3 = V_0;
		BufferSerializer_1_SerializeValue_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m7B4A33CD1D215EDE706B9F3F54F930263A54879F((&___0_serializer), L_2, L_3, NULL);
		return;
	}
}
IL2CPP_EXTERN_C  void AnimationTriggerMessage_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m831257AA195AD81E1B8876E6192CE70252D31F1D_AdjustorThunk (RuntimeObject* __this, BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0 ___0_serializer, const RuntimeMethod* method)
{
	AnimationTriggerMessage_t5E9BAC8B6B7C3A3D79E9448C8C735380FBFC72FF* _thisAdjusted;
	_thisAdjusted = il2cpp_codegen_get_raw_data<AnimationTriggerMessage_t5E9BAC8B6B7C3A3D79E9448C8C735380FBFC72FF>(__this);
	AnimationTriggerMessage_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m831257AA195AD81E1B8876E6192CE70252D31F1D(_thisAdjusted, ___0_serializer, method);
}
// Method Definition Index: 70240
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AnimationTriggerMessage_NetworkSerialize_TisIl2CppFullySharedGenericAny_m12CFDF3873F81396A10F13261B1DF4F83D0A99D8_fshared (AnimationTriggerMessage_t5E9BAC8B6B7C3A3D79E9448C8C735380FBFC72FF* __this, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 ___0_serializer, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	//<source_info:<no-source>:1>
	ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		int32_t* L_0 = (int32_t*)(&__this->___Hash);
		il2cpp_codegen_initobj((&V_0), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_1 = V_0;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, int32_t*, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 1)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_0, L_1, il2cpp_rgctx_method(method->rgctx_data, 1));
		bool* L_2 = (bool*)(&__this->___IsTriggerSet);
		il2cpp_codegen_initobj((&V_0), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_3 = V_0;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, bool*, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 2)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_2, L_3, il2cpp_rgctx_method(method->rgctx_data, 2));
		return;
	}
}
IL2CPP_EXTERN_C  void AnimationTriggerMessage_NetworkSerialize_TisIl2CppFullySharedGenericAny_m12CFDF3873F81396A10F13261B1DF4F83D0A99D8_AdjustorThunk (RuntimeObject* __this, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 ___0_serializer, const RuntimeMethod* method)
{
	AnimationTriggerMessage_t5E9BAC8B6B7C3A3D79E9448C8C735380FBFC72FF* _thisAdjusted;
	_thisAdjusted = il2cpp_codegen_get_raw_data<AnimationTriggerMessage_t5E9BAC8B6B7C3A3D79E9448C8C735380FBFC72FF>(__this);
	AnimationTriggerMessage_NetworkSerialize_TisIl2CppFullySharedGenericAny_m12CFDF3873F81396A10F13261B1DF4F83D0A99D8(_thisAdjusted, ___0_serializer, method);
}
// Method Definition Index: 70239
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ParametersUpdateMessage_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_mDAD146156C033575D7A28EE56A00A98731B84A0A (ParametersUpdateMessage_tA77A911264605B5AE8FE181D2A1BA78A4E2B41CC* __this, BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B ___0_serializer, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	//<source_info:<no-source>:1>
	ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** L_0 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031**)(&__this->___Parameters);
		il2cpp_codegen_initobj((&V_0), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_1 = V_0;
		BufferSerializer_1_SerializeValue_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m1D4559355D8982D0FDFBECB67C3DFD8B5977522F((&___0_serializer), L_0, L_1, il2cpp_rgctx_method(method->rgctx_data, 1));
		return;
	}
}
IL2CPP_EXTERN_C  void ParametersUpdateMessage_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_mDAD146156C033575D7A28EE56A00A98731B84A0A_AdjustorThunk (RuntimeObject* __this, BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B ___0_serializer, const RuntimeMethod* method)
{
	ParametersUpdateMessage_tA77A911264605B5AE8FE181D2A1BA78A4E2B41CC* _thisAdjusted;
	_thisAdjusted = il2cpp_codegen_get_raw_data<ParametersUpdateMessage_tA77A911264605B5AE8FE181D2A1BA78A4E2B41CC>(__this);
	ParametersUpdateMessage_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_mDAD146156C033575D7A28EE56A00A98731B84A0A(_thisAdjusted, ___0_serializer, method);
}
// Method Definition Index: 70239
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ParametersUpdateMessage_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m69B6E53197F936BB20E239A5CE6795AE55497DF9 (ParametersUpdateMessage_tA77A911264605B5AE8FE181D2A1BA78A4E2B41CC* __this, BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0 ___0_serializer, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** L_0 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031**)(&__this->___Parameters);
		il2cpp_codegen_initobj((&V_0), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_1 = V_0;
		BufferSerializer_1_SerializeValue_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_mAD89D6AD1671054722C3ECC148291524285C35D8((&___0_serializer), L_0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C  void ParametersUpdateMessage_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m69B6E53197F936BB20E239A5CE6795AE55497DF9_AdjustorThunk (RuntimeObject* __this, BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0 ___0_serializer, const RuntimeMethod* method)
{
	ParametersUpdateMessage_tA77A911264605B5AE8FE181D2A1BA78A4E2B41CC* _thisAdjusted;
	_thisAdjusted = il2cpp_codegen_get_raw_data<ParametersUpdateMessage_tA77A911264605B5AE8FE181D2A1BA78A4E2B41CC>(__this);
	ParametersUpdateMessage_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m69B6E53197F936BB20E239A5CE6795AE55497DF9(_thisAdjusted, ___0_serializer, method);
}
// Method Definition Index: 70239
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ParametersUpdateMessage_NetworkSerialize_TisIl2CppFullySharedGenericAny_mB78A86C8B7A4255E424BE9FEC1CFE27AD6EBA453_fshared (ParametersUpdateMessage_tA77A911264605B5AE8FE181D2A1BA78A4E2B41CC* __this, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 ___0_serializer, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	//<source_info:<no-source>:1>
	ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** L_0 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031**)(&__this->___Parameters);
		il2cpp_codegen_initobj((&V_0), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_1 = V_0;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031**, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 1)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_0, L_1, il2cpp_rgctx_method(method->rgctx_data, 1));
		return;
	}
}
IL2CPP_EXTERN_C  void ParametersUpdateMessage_NetworkSerialize_TisIl2CppFullySharedGenericAny_mB78A86C8B7A4255E424BE9FEC1CFE27AD6EBA453_AdjustorThunk (RuntimeObject* __this, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 ___0_serializer, const RuntimeMethod* method)
{
	ParametersUpdateMessage_tA77A911264605B5AE8FE181D2A1BA78A4E2B41CC* _thisAdjusted;
	_thisAdjusted = il2cpp_codegen_get_raw_data<ParametersUpdateMessage_tA77A911264605B5AE8FE181D2A1BA78A4E2B41CC>(__this);
	ParametersUpdateMessage_NetworkSerialize_TisIl2CppFullySharedGenericAny_mB78A86C8B7A4255E424BE9FEC1CFE27AD6EBA453(_thisAdjusted, ___0_serializer, method);
}
// Method Definition Index: 68857
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SceneMap_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_m9853256DC4E5A60E8A9D416599B7D6E4153A2AF6 (SceneMap_tD765F13EE91B6DB8366332CB2C054CC47DE5AA7E* __this, BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B ___0_serializer, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral000D6B4454BE3C3F0EB965604C293E0C0FE8F28E);
		s_Il2CppMethodInitialized = true;
	}
	//<source_info:<no-source>:1>
	ForEnums_tD6A048FB8E80A3A6DC7DE4B6DE48D635362F7511 V_0;
	memset((&V_0), 0, sizeof(V_0));
	ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 V_1;
	memset((&V_1), 0, sizeof(V_1));
	ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 V_2;
	memset((&V_2), 0, sizeof(V_2));
	{
		int32_t* L_0 = (int32_t*)(&__this->___MapType);
		il2cpp_codegen_initobj((&V_0), sizeof(ForEnums_tD6A048FB8E80A3A6DC7DE4B6DE48D635362F7511));
		ForEnums_tD6A048FB8E80A3A6DC7DE4B6DE48D635362F7511 L_1 = V_0;
		BufferSerializer_1_SerializeValue_TisMapTypes_tB24369EF24F9A74D2FA0CA938B55392EA305822C_m2AC2341E6BB3C951514A39EFC0EAA7360C82BADB((&___0_serializer), L_0, L_1, NULL);
		bool* L_2 = (bool*)(&__this->___ScenePresent);
		il2cpp_codegen_initobj((&V_1), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_3 = V_1;
		BufferSerializer_1_SerializeValue_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m53224A30FDD9F347134C5F058A4AA1902F046703((&___0_serializer), L_2, L_3, NULL);
		bool L_4;
		L_4 = BufferSerializer_1_get_IsReader_m6391807CBC3E99FB5B0C0306A3407B988C01270B((&___0_serializer), NULL);
		if (!L_4)
		{
			goto IL_0040;
		}
	}
	{
		__this->___SceneName = _stringLiteral000D6B4454BE3C3F0EB965604C293E0C0FE8F28E;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___SceneName), (void*)_stringLiteral000D6B4454BE3C3F0EB965604C293E0C0FE8F28E);
	}

IL_0040:
	{
		bool L_5 = __this->___ScenePresent;
		if (!L_5)
		{
			goto IL_006c;
		}
	}
	{
		String_t** L_6 = (String_t**)(&__this->___SceneName);
		BufferSerializer_1_SerializeValue_mFC3CDB7ADDAFE46729C25BAAACFC409528BD2995((&___0_serializer), L_6, (bool)0, NULL);
		int32_t* L_7 = (int32_t*)(&__this->___LocalHandle);
		il2cpp_codegen_initobj((&V_1), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_8 = V_1;
		BufferSerializer_1_SerializeValue_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m59AF230EB443B685CB322B5AA0898734756EADD7((&___0_serializer), L_7, L_8, NULL);
	}

IL_006c:
	{
		int32_t* L_9 = (int32_t*)(&__this->___ServerHandle);
		il2cpp_codegen_initobj((&V_1), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_10 = V_1;
		BufferSerializer_1_SerializeValue_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m59AF230EB443B685CB322B5AA0898734756EADD7((&___0_serializer), L_9, L_10, NULL);
		int32_t* L_11 = (int32_t*)(&__this->___MappedLocalHandle);
		il2cpp_codegen_initobj((&V_1), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_12 = V_1;
		BufferSerializer_1_SerializeValue_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m59AF230EB443B685CB322B5AA0898734756EADD7((&___0_serializer), L_11, L_12, NULL);
		bool L_13;
		L_13 = BufferSerializer_1_get_IsWriter_m6978D539067CE30EC81B6491589C7C30A1E16C28((&___0_serializer), NULL);
		if (!L_13)
		{
			goto IL_0134;
		}
	}
	{
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* L_14 = (NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D*)(&__this->___m_LocalHandle);
		bool L_15;
		L_15 = NetworkSceneHandle_IsEmpty_mEB284E9B208574F9149A96A5DCF02E52DD5D3C1B(L_14, NULL);
		if (!L_15)
		{
			goto IL_00d4;
		}
	}
	{
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_16 = __this->___LocalSceneHandle;
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_17;
		L_17 = SceneHandle_get_None_m4E17CDCF9D442196A84BE18E986F65ABA8FA8B87(NULL);
		bool L_18;
		L_18 = SceneHandle_op_Inequality_mA715EC25F82CBA38DF43336E584226EEAE7A3223(L_16, L_17, NULL);
		if (!L_18)
		{
			goto IL_00d4;
		}
	}
	{
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_19 = __this->___LocalSceneHandle;
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D L_20;
		L_20 = NetworkSceneHandle_op_Implicit_m4E8B9C02A2029CC121E02E6AA0BC7F7D3F782824(L_19, NULL);
		__this->___m_LocalHandle = L_20;
	}

IL_00d4:
	{
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* L_21 = (NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D*)(&__this->___m_ServerHandle);
		bool L_22;
		L_22 = NetworkSceneHandle_IsEmpty_mEB284E9B208574F9149A96A5DCF02E52DD5D3C1B(L_21, NULL);
		if (!L_22)
		{
			goto IL_0104;
		}
	}
	{
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_23 = __this->___ServerSceneHandle;
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_24;
		L_24 = SceneHandle_get_None_m4E17CDCF9D442196A84BE18E986F65ABA8FA8B87(NULL);
		bool L_25;
		L_25 = SceneHandle_op_Inequality_mA715EC25F82CBA38DF43336E584226EEAE7A3223(L_23, L_24, NULL);
		if (!L_25)
		{
			goto IL_0104;
		}
	}
	{
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_26 = __this->___ServerSceneHandle;
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D L_27;
		L_27 = NetworkSceneHandle_op_Implicit_m4E8B9C02A2029CC121E02E6AA0BC7F7D3F782824(L_26, NULL);
		__this->___m_ServerHandle = L_27;
	}

IL_0104:
	{
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* L_28 = (NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D*)(&__this->___m_MappedLocalHandle);
		bool L_29;
		L_29 = NetworkSceneHandle_IsEmpty_mEB284E9B208574F9149A96A5DCF02E52DD5D3C1B(L_28, NULL);
		if (!L_29)
		{
			goto IL_0134;
		}
	}
	{
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_30 = __this->___MappedLocalSceneHandle;
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_31;
		L_31 = SceneHandle_get_None_m4E17CDCF9D442196A84BE18E986F65ABA8FA8B87(NULL);
		bool L_32;
		L_32 = SceneHandle_op_Inequality_mA715EC25F82CBA38DF43336E584226EEAE7A3223(L_30, L_31, NULL);
		if (!L_32)
		{
			goto IL_0134;
		}
	}
	{
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_33 = __this->___MappedLocalSceneHandle;
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D L_34;
		L_34 = NetworkSceneHandle_op_Implicit_m4E8B9C02A2029CC121E02E6AA0BC7F7D3F782824(L_33, NULL);
		__this->___m_MappedLocalHandle = L_34;
	}

IL_0134:
	{
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* L_35 = (NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D*)(&__this->___m_LocalHandle);
		il2cpp_codegen_initobj((&V_2), sizeof(ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3));
		ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 L_36 = V_2;
		BufferSerializer_1_SerializeValue_TisNetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D_m8291063A935C8DCA24338F6C4EE6E3F14117C1E8((&___0_serializer), L_35, L_36, NULL);
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* L_37 = (NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D*)(&__this->___m_ServerHandle);
		il2cpp_codegen_initobj((&V_2), sizeof(ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3));
		ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 L_38 = V_2;
		BufferSerializer_1_SerializeValue_TisNetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D_m8291063A935C8DCA24338F6C4EE6E3F14117C1E8((&___0_serializer), L_37, L_38, NULL);
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* L_39 = (NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D*)(&__this->___m_MappedLocalHandle);
		il2cpp_codegen_initobj((&V_2), sizeof(ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3));
		ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 L_40 = V_2;
		BufferSerializer_1_SerializeValue_TisNetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D_m8291063A935C8DCA24338F6C4EE6E3F14117C1E8((&___0_serializer), L_39, L_40, NULL);
		bool L_41;
		L_41 = BufferSerializer_1_get_IsReader_m6391807CBC3E99FB5B0C0306A3407B988C01270B((&___0_serializer), NULL);
		if (!L_41)
		{
			goto IL_01b2;
		}
	}
	{
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D L_42 = __this->___m_ServerHandle;
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_43;
		L_43 = NetworkSceneHandle_op_Implicit_m071F9D70086FE159910ABC5BE5358EB76761C589_inline(L_42, NULL);
		__this->___ServerSceneHandle = L_43;
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D L_44 = __this->___m_LocalHandle;
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_45;
		L_45 = NetworkSceneHandle_op_Implicit_m071F9D70086FE159910ABC5BE5358EB76761C589_inline(L_44, NULL);
		__this->___ServerSceneHandle = L_45;
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D L_46 = __this->___m_MappedLocalHandle;
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_47;
		L_47 = NetworkSceneHandle_op_Implicit_m071F9D70086FE159910ABC5BE5358EB76761C589_inline(L_46, NULL);
		__this->___ServerSceneHandle = L_47;
	}

IL_01b2:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void SceneMap_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_m9853256DC4E5A60E8A9D416599B7D6E4153A2AF6_AdjustorThunk (RuntimeObject* __this, BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B ___0_serializer, const RuntimeMethod* method)
{
	SceneMap_tD765F13EE91B6DB8366332CB2C054CC47DE5AA7E* _thisAdjusted;
	_thisAdjusted = il2cpp_codegen_get_raw_data<SceneMap_tD765F13EE91B6DB8366332CB2C054CC47DE5AA7E>(__this);
	SceneMap_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_m9853256DC4E5A60E8A9D416599B7D6E4153A2AF6(_thisAdjusted, ___0_serializer, method);
}
// Method Definition Index: 68857
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SceneMap_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m9A4D0AB395FD9325D6F1E30FC65753F2C6684C21 (SceneMap_tD765F13EE91B6DB8366332CB2C054CC47DE5AA7E* __this, BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0 ___0_serializer, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral000D6B4454BE3C3F0EB965604C293E0C0FE8F28E);
		s_Il2CppMethodInitialized = true;
	}
	//<source_info:<no-source>:1>
	ForEnums_tD6A048FB8E80A3A6DC7DE4B6DE48D635362F7511 V_0;
	memset((&V_0), 0, sizeof(V_0));
	ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 V_1;
	memset((&V_1), 0, sizeof(V_1));
	ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 V_2;
	memset((&V_2), 0, sizeof(V_2));
	{
		int32_t* L_0 = (int32_t*)(&__this->___MapType);
		il2cpp_codegen_initobj((&V_0), sizeof(ForEnums_tD6A048FB8E80A3A6DC7DE4B6DE48D635362F7511));
		ForEnums_tD6A048FB8E80A3A6DC7DE4B6DE48D635362F7511 L_1 = V_0;
		BufferSerializer_1_SerializeValue_TisMapTypes_tB24369EF24F9A74D2FA0CA938B55392EA305822C_m9BDA7530FCB1F971940081D0F60F9A5118CB418E((&___0_serializer), L_0, L_1, NULL);
		bool* L_2 = (bool*)(&__this->___ScenePresent);
		il2cpp_codegen_initobj((&V_1), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_3 = V_1;
		BufferSerializer_1_SerializeValue_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m7B4A33CD1D215EDE706B9F3F54F930263A54879F((&___0_serializer), L_2, L_3, NULL);
		bool L_4;
		L_4 = BufferSerializer_1_get_IsReader_mBAAFBF1B83961D969792A2CDB52D3EE2B05653DF((&___0_serializer), NULL);
		if (!L_4)
		{
			goto IL_0040;
		}
	}
	{
		__this->___SceneName = _stringLiteral000D6B4454BE3C3F0EB965604C293E0C0FE8F28E;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___SceneName), (void*)_stringLiteral000D6B4454BE3C3F0EB965604C293E0C0FE8F28E);
	}

IL_0040:
	{
		bool L_5 = __this->___ScenePresent;
		if (!L_5)
		{
			goto IL_006c;
		}
	}
	{
		String_t** L_6 = (String_t**)(&__this->___SceneName);
		BufferSerializer_1_SerializeValue_mB617CF6234422CCCAD113FE97A1D5E18DB802962((&___0_serializer), L_6, (bool)0, NULL);
		int32_t* L_7 = (int32_t*)(&__this->___LocalHandle);
		il2cpp_codegen_initobj((&V_1), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_8 = V_1;
		BufferSerializer_1_SerializeValue_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m77A3B1A6805879DFC74A55FBE9F076C81CF22869((&___0_serializer), L_7, L_8, NULL);
	}

IL_006c:
	{
		int32_t* L_9 = (int32_t*)(&__this->___ServerHandle);
		il2cpp_codegen_initobj((&V_1), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_10 = V_1;
		BufferSerializer_1_SerializeValue_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m77A3B1A6805879DFC74A55FBE9F076C81CF22869((&___0_serializer), L_9, L_10, NULL);
		int32_t* L_11 = (int32_t*)(&__this->___MappedLocalHandle);
		il2cpp_codegen_initobj((&V_1), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_12 = V_1;
		BufferSerializer_1_SerializeValue_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m77A3B1A6805879DFC74A55FBE9F076C81CF22869((&___0_serializer), L_11, L_12, NULL);
		bool L_13;
		L_13 = BufferSerializer_1_get_IsWriter_mA81CADE3680B019327BD43C92F4743B2140A83EB((&___0_serializer), NULL);
		if (!L_13)
		{
			goto IL_0134;
		}
	}
	{
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* L_14 = (NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D*)(&__this->___m_LocalHandle);
		bool L_15;
		L_15 = NetworkSceneHandle_IsEmpty_mEB284E9B208574F9149A96A5DCF02E52DD5D3C1B(L_14, NULL);
		if (!L_15)
		{
			goto IL_00d4;
		}
	}
	{
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_16 = __this->___LocalSceneHandle;
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_17;
		L_17 = SceneHandle_get_None_m4E17CDCF9D442196A84BE18E986F65ABA8FA8B87(NULL);
		bool L_18;
		L_18 = SceneHandle_op_Inequality_mA715EC25F82CBA38DF43336E584226EEAE7A3223(L_16, L_17, NULL);
		if (!L_18)
		{
			goto IL_00d4;
		}
	}
	{
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_19 = __this->___LocalSceneHandle;
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D L_20;
		L_20 = NetworkSceneHandle_op_Implicit_m4E8B9C02A2029CC121E02E6AA0BC7F7D3F782824(L_19, NULL);
		__this->___m_LocalHandle = L_20;
	}

IL_00d4:
	{
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* L_21 = (NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D*)(&__this->___m_ServerHandle);
		bool L_22;
		L_22 = NetworkSceneHandle_IsEmpty_mEB284E9B208574F9149A96A5DCF02E52DD5D3C1B(L_21, NULL);
		if (!L_22)
		{
			goto IL_0104;
		}
	}
	{
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_23 = __this->___ServerSceneHandle;
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_24;
		L_24 = SceneHandle_get_None_m4E17CDCF9D442196A84BE18E986F65ABA8FA8B87(NULL);
		bool L_25;
		L_25 = SceneHandle_op_Inequality_mA715EC25F82CBA38DF43336E584226EEAE7A3223(L_23, L_24, NULL);
		if (!L_25)
		{
			goto IL_0104;
		}
	}
	{
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_26 = __this->___ServerSceneHandle;
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D L_27;
		L_27 = NetworkSceneHandle_op_Implicit_m4E8B9C02A2029CC121E02E6AA0BC7F7D3F782824(L_26, NULL);
		__this->___m_ServerHandle = L_27;
	}

IL_0104:
	{
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* L_28 = (NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D*)(&__this->___m_MappedLocalHandle);
		bool L_29;
		L_29 = NetworkSceneHandle_IsEmpty_mEB284E9B208574F9149A96A5DCF02E52DD5D3C1B(L_28, NULL);
		if (!L_29)
		{
			goto IL_0134;
		}
	}
	{
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_30 = __this->___MappedLocalSceneHandle;
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_31;
		L_31 = SceneHandle_get_None_m4E17CDCF9D442196A84BE18E986F65ABA8FA8B87(NULL);
		bool L_32;
		L_32 = SceneHandle_op_Inequality_mA715EC25F82CBA38DF43336E584226EEAE7A3223(L_30, L_31, NULL);
		if (!L_32)
		{
			goto IL_0134;
		}
	}
	{
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_33 = __this->___MappedLocalSceneHandle;
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D L_34;
		L_34 = NetworkSceneHandle_op_Implicit_m4E8B9C02A2029CC121E02E6AA0BC7F7D3F782824(L_33, NULL);
		__this->___m_MappedLocalHandle = L_34;
	}

IL_0134:
	{
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* L_35 = (NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D*)(&__this->___m_LocalHandle);
		il2cpp_codegen_initobj((&V_2), sizeof(ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3));
		ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 L_36 = V_2;
		BufferSerializer_1_SerializeValue_TisNetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D_mADBE51CDBAEF491B1ACBE311CC6940C791075273((&___0_serializer), L_35, L_36, NULL);
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* L_37 = (NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D*)(&__this->___m_ServerHandle);
		il2cpp_codegen_initobj((&V_2), sizeof(ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3));
		ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 L_38 = V_2;
		BufferSerializer_1_SerializeValue_TisNetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D_mADBE51CDBAEF491B1ACBE311CC6940C791075273((&___0_serializer), L_37, L_38, NULL);
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* L_39 = (NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D*)(&__this->___m_MappedLocalHandle);
		il2cpp_codegen_initobj((&V_2), sizeof(ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3));
		ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 L_40 = V_2;
		BufferSerializer_1_SerializeValue_TisNetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D_mADBE51CDBAEF491B1ACBE311CC6940C791075273((&___0_serializer), L_39, L_40, NULL);
		bool L_41;
		L_41 = BufferSerializer_1_get_IsReader_mBAAFBF1B83961D969792A2CDB52D3EE2B05653DF((&___0_serializer), NULL);
		if (!L_41)
		{
			goto IL_01b2;
		}
	}
	{
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D L_42 = __this->___m_ServerHandle;
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_43;
		L_43 = NetworkSceneHandle_op_Implicit_m071F9D70086FE159910ABC5BE5358EB76761C589_inline(L_42, NULL);
		__this->___ServerSceneHandle = L_43;
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D L_44 = __this->___m_LocalHandle;
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_45;
		L_45 = NetworkSceneHandle_op_Implicit_m071F9D70086FE159910ABC5BE5358EB76761C589_inline(L_44, NULL);
		__this->___ServerSceneHandle = L_45;
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D L_46 = __this->___m_MappedLocalHandle;
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_47;
		L_47 = NetworkSceneHandle_op_Implicit_m071F9D70086FE159910ABC5BE5358EB76761C589_inline(L_46, NULL);
		__this->___ServerSceneHandle = L_47;
	}

IL_01b2:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void SceneMap_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m9A4D0AB395FD9325D6F1E30FC65753F2C6684C21_AdjustorThunk (RuntimeObject* __this, BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0 ___0_serializer, const RuntimeMethod* method)
{
	SceneMap_tD765F13EE91B6DB8366332CB2C054CC47DE5AA7E* _thisAdjusted;
	_thisAdjusted = il2cpp_codegen_get_raw_data<SceneMap_tD765F13EE91B6DB8366332CB2C054CC47DE5AA7E>(__this);
	SceneMap_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m9A4D0AB395FD9325D6F1E30FC65753F2C6684C21(_thisAdjusted, ___0_serializer, method);
}
// Method Definition Index: 68857
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SceneMap_NetworkSerialize_TisIl2CppFullySharedGenericAny_m2DE7C2FEDDE74AF6ADEE717F91A54EFCBBC9C13D_fshared (SceneMap_tD765F13EE91B6DB8366332CB2C054CC47DE5AA7E* __this, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 ___0_serializer, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral000D6B4454BE3C3F0EB965604C293E0C0FE8F28E);
		il2cpp_rgctx_method_init(method);
	}
	//<source_info:<no-source>:1>
	ForEnums_tD6A048FB8E80A3A6DC7DE4B6DE48D635362F7511 V_0;
	memset((&V_0), 0, sizeof(V_0));
	ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 V_1;
	memset((&V_1), 0, sizeof(V_1));
	ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 V_2;
	memset((&V_2), 0, sizeof(V_2));
	{
		int32_t* L_0 = (int32_t*)(&__this->___MapType);
		il2cpp_codegen_initobj((&V_0), sizeof(ForEnums_tD6A048FB8E80A3A6DC7DE4B6DE48D635362F7511));
		ForEnums_tD6A048FB8E80A3A6DC7DE4B6DE48D635362F7511 L_1 = V_0;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, int32_t*, ForEnums_tD6A048FB8E80A3A6DC7DE4B6DE48D635362F7511, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 1)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_0, L_1, il2cpp_rgctx_method(method->rgctx_data, 1));
		bool* L_2 = (bool*)(&__this->___ScenePresent);
		il2cpp_codegen_initobj((&V_1), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_3 = V_1;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, bool*, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 2)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_2, L_3, il2cpp_rgctx_method(method->rgctx_data, 2));
		bool L_4;
		L_4 = ((  bool (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 3)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, il2cpp_rgctx_method(method->rgctx_data, 3));
		if (!L_4)
		{
			goto IL_0040;
		}
	}
	{
		__this->___SceneName = _stringLiteral000D6B4454BE3C3F0EB965604C293E0C0FE8F28E;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___SceneName), (void*)_stringLiteral000D6B4454BE3C3F0EB965604C293E0C0FE8F28E);
	}

IL_0040:
	{
		bool L_5 = __this->___ScenePresent;
		if (!L_5)
		{
			goto IL_006c;
		}
	}
	{
		String_t** L_6 = (String_t**)(&__this->___SceneName);
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, String_t**, bool, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 4)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_6, (bool)0, il2cpp_rgctx_method(method->rgctx_data, 4));
		int32_t* L_7 = (int32_t*)(&__this->___LocalHandle);
		il2cpp_codegen_initobj((&V_1), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_8 = V_1;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, int32_t*, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 5)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_7, L_8, il2cpp_rgctx_method(method->rgctx_data, 5));
	}

IL_006c:
	{
		int32_t* L_9 = (int32_t*)(&__this->___ServerHandle);
		il2cpp_codegen_initobj((&V_1), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_10 = V_1;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, int32_t*, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 5)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_9, L_10, il2cpp_rgctx_method(method->rgctx_data, 5));
		int32_t* L_11 = (int32_t*)(&__this->___MappedLocalHandle);
		il2cpp_codegen_initobj((&V_1), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_12 = V_1;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, int32_t*, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 5)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 5));
		bool L_13;
		L_13 = ((  bool (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 6)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, il2cpp_rgctx_method(method->rgctx_data, 6));
		if (!L_13)
		{
			goto IL_0134;
		}
	}
	{
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* L_14 = (NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D*)(&__this->___m_LocalHandle);
		bool L_15;
		L_15 = NetworkSceneHandle_IsEmpty_mEB284E9B208574F9149A96A5DCF02E52DD5D3C1B(L_14, NULL);
		if (!L_15)
		{
			goto IL_00d4;
		}
	}
	{
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_16 = __this->___LocalSceneHandle;
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_17;
		L_17 = SceneHandle_get_None_m4E17CDCF9D442196A84BE18E986F65ABA8FA8B87(NULL);
		bool L_18;
		L_18 = SceneHandle_op_Inequality_mA715EC25F82CBA38DF43336E584226EEAE7A3223(L_16, L_17, NULL);
		if (!L_18)
		{
			goto IL_00d4;
		}
	}
	{
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_19 = __this->___LocalSceneHandle;
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D L_20;
		L_20 = NetworkSceneHandle_op_Implicit_m4E8B9C02A2029CC121E02E6AA0BC7F7D3F782824(L_19, NULL);
		__this->___m_LocalHandle = L_20;
	}

IL_00d4:
	{
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* L_21 = (NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D*)(&__this->___m_ServerHandle);
		bool L_22;
		L_22 = NetworkSceneHandle_IsEmpty_mEB284E9B208574F9149A96A5DCF02E52DD5D3C1B(L_21, NULL);
		if (!L_22)
		{
			goto IL_0104;
		}
	}
	{
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_23 = __this->___ServerSceneHandle;
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_24;
		L_24 = SceneHandle_get_None_m4E17CDCF9D442196A84BE18E986F65ABA8FA8B87(NULL);
		bool L_25;
		L_25 = SceneHandle_op_Inequality_mA715EC25F82CBA38DF43336E584226EEAE7A3223(L_23, L_24, NULL);
		if (!L_25)
		{
			goto IL_0104;
		}
	}
	{
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_26 = __this->___ServerSceneHandle;
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D L_27;
		L_27 = NetworkSceneHandle_op_Implicit_m4E8B9C02A2029CC121E02E6AA0BC7F7D3F782824(L_26, NULL);
		__this->___m_ServerHandle = L_27;
	}

IL_0104:
	{
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* L_28 = (NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D*)(&__this->___m_MappedLocalHandle);
		bool L_29;
		L_29 = NetworkSceneHandle_IsEmpty_mEB284E9B208574F9149A96A5DCF02E52DD5D3C1B(L_28, NULL);
		if (!L_29)
		{
			goto IL_0134;
		}
	}
	{
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_30 = __this->___MappedLocalSceneHandle;
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_31;
		L_31 = SceneHandle_get_None_m4E17CDCF9D442196A84BE18E986F65ABA8FA8B87(NULL);
		bool L_32;
		L_32 = SceneHandle_op_Inequality_mA715EC25F82CBA38DF43336E584226EEAE7A3223(L_30, L_31, NULL);
		if (!L_32)
		{
			goto IL_0134;
		}
	}
	{
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_33 = __this->___MappedLocalSceneHandle;
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D L_34;
		L_34 = NetworkSceneHandle_op_Implicit_m4E8B9C02A2029CC121E02E6AA0BC7F7D3F782824(L_33, NULL);
		__this->___m_MappedLocalHandle = L_34;
	}

IL_0134:
	{
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* L_35 = (NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D*)(&__this->___m_LocalHandle);
		il2cpp_codegen_initobj((&V_2), sizeof(ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3));
		ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 L_36 = V_2;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D*, ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 7)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_35, L_36, il2cpp_rgctx_method(method->rgctx_data, 7));
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* L_37 = (NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D*)(&__this->___m_ServerHandle);
		il2cpp_codegen_initobj((&V_2), sizeof(ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3));
		ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 L_38 = V_2;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D*, ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 7)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_37, L_38, il2cpp_rgctx_method(method->rgctx_data, 7));
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D* L_39 = (NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D*)(&__this->___m_MappedLocalHandle);
		il2cpp_codegen_initobj((&V_2), sizeof(ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3));
		ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 L_40 = V_2;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D*, ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 7)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_39, L_40, il2cpp_rgctx_method(method->rgctx_data, 7));
		bool L_41;
		L_41 = ((  bool (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 3)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, il2cpp_rgctx_method(method->rgctx_data, 3));
		if (!L_41)
		{
			goto IL_01b2;
		}
	}
	{
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D L_42 = __this->___m_ServerHandle;
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_43;
		L_43 = NetworkSceneHandle_op_Implicit_m071F9D70086FE159910ABC5BE5358EB76761C589_inline(L_42, NULL);
		__this->___ServerSceneHandle = L_43;
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D L_44 = __this->___m_LocalHandle;
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_45;
		L_45 = NetworkSceneHandle_op_Implicit_m071F9D70086FE159910ABC5BE5358EB76761C589_inline(L_44, NULL);
		__this->___ServerSceneHandle = L_45;
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D L_46 = __this->___m_MappedLocalHandle;
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_47;
		L_47 = NetworkSceneHandle_op_Implicit_m071F9D70086FE159910ABC5BE5358EB76761C589_inline(L_46, NULL);
		__this->___ServerSceneHandle = L_47;
	}

IL_01b2:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void SceneMap_NetworkSerialize_TisIl2CppFullySharedGenericAny_m2DE7C2FEDDE74AF6ADEE717F91A54EFCBBC9C13D_AdjustorThunk (RuntimeObject* __this, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 ___0_serializer, const RuntimeMethod* method)
{
	SceneMap_tD765F13EE91B6DB8366332CB2C054CC47DE5AA7E* _thisAdjusted;
	_thisAdjusted = il2cpp_codegen_get_raw_data<SceneMap_tD765F13EE91B6DB8366332CB2C054CC47DE5AA7E>(__this);
	SceneMap_NetworkSerialize_TisIl2CppFullySharedGenericAny_m2DE7C2FEDDE74AF6ADEE717F91A54EFCBBC9C13D(_thisAdjusted, ___0_serializer, method);
}
// Method Definition Index: 70454
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetworkTransformState_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_m315FE7B6046C0603C6C2F4904F76DDE868D9E59F (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B ___0_serializer, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC_StaticInit);
	//<source_info:<no-source>:1>
	int32_t V_0 = 0;
	bool V_1 = false;
	uint32_t V_2 = 0;
	ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 V_3;
	memset((&V_3), 0, sizeof(V_3));
	ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 V_4;
	memset((&V_4), 0, sizeof(V_4));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_5;
	memset((&V_5), 0, sizeof(V_5));
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B92_0 = NULL;
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B90_0 = NULL;
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B91_0 = NULL;
	int32_t G_B93_0 = 0;
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B93_1 = NULL;
	{
		V_0 = 0;
		bool L_0;
		L_0 = BufferSerializer_1_get_IsWriter_m6978D539067CE30EC81B6491589C7C30A1E16C28((&___0_serializer), NULL);
		V_1 = L_0;
		bool L_1 = V_1;
		if (!L_1)
		{
			goto IL_0028;
		}
	}
	{
		FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC L_2;
		L_2 = BufferSerializer_1_GetFastBufferWriter_m9C29FD83F1F84F7DB243974892CB6612AE9ACCE9((&___0_serializer), NULL);
		__this->___m_Writer = L_2;
		FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC* L_3 = (FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC*)(&__this->___m_Writer);
		CHECKED_LOCAL_INIT(FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC_StaticInit,(FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		int32_t L_4;
		L_4 = FastBufferWriter_get_Position_m87642B5268B41B7D15D4E628DF93A5B5776A4B05_inline(L_3, NULL);
		V_0 = L_4;
		goto IL_0041;
	}

IL_0028:
	{
		FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 L_5;
		L_5 = BufferSerializer_1_GetFastBufferReader_mF14C151E60E6525341AD31B18744F2DCC23DE063((&___0_serializer), NULL);
		__this->___m_Reader = L_5;
		FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99* L_6 = (FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99*)(&__this->___m_Reader);
		int32_t L_7;
		L_7 = FastBufferReader_get_Position_m6B9DC9ECC9F2D943EA0103248E10AB9B95C8F4CF_inline(L_6, NULL);
		V_0 = L_7;
	}

IL_0041:
	{
		bool L_8 = V_1;
		if (!L_8)
		{
			goto IL_00e6;
		}
	}
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_9 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_10 = L_9->___UseUnreliableDeltas;
		if (!L_10)
		{
			goto IL_00b1;
		}
	}
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_11 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_12 = L_11->___IsTeleportingNextFrame;
		if (L_12)
		{
			goto IL_0095;
		}
	}
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_13 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_14 = L_13->___IsSynchronizing;
		if (L_14)
		{
			goto IL_0095;
		}
	}
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_15 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_16 = L_15->___UnreliableFrameSync;
		if (L_16)
		{
			goto IL_0095;
		}
	}
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_17 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_18 = L_17->___UseHalfFloatPrecision;
		if (!L_18)
		{
			goto IL_00a3;
		}
	}
	{
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_19 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		bool L_20 = L_19->___CollapsedDeltaIntoBase;
		if (!L_20)
		{
			goto IL_00a3;
		}
	}

IL_0095:
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_21 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		L_21->___ReliableSequenced = (bool)1;
		goto IL_00bd;
	}

IL_00a3:
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_22 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		L_22->___ReliableSequenced = (bool)0;
		goto IL_00bd;
	}

IL_00b1:
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_23 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		L_23->___ReliableSequenced = (bool)1;
	}

IL_00bd:
	{
		FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC L_24 = __this->___m_Writer;
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_25 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		uint32_t L_26;
		L_26 = FlagStates_GetBitsetRepresentation_m7002081C4C5BD54947BD04940B1FA592C83CEC3B_inline(L_25, NULL);
		BytePacker_WriteValueBitPacked_m50033FEA83560CA7AF9668B3C7352E013D518F11(L_24, L_26, NULL);
		FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC L_27 = __this->___m_Writer;
		int32_t L_28 = __this->___NetworkTick;
		BytePacker_WriteValueBitPacked_m510F6322BA0F2C85AF9527A7927FF9B03F0AE613(L_27, L_28, NULL);
		goto IL_0110;
	}

IL_00e6:
	{
		FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 L_29 = __this->___m_Reader;
		ByteUnpacker_ReadValueBitPacked_mACA5F48002EFB41F31DB0F4AAB4936A2E423DCA4(L_29, (&V_2), NULL);
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_30 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		uint32_t L_31 = V_2;
		FlagStates_SetStateFromBitset_m88B26BC623EA70281C6F7A973DC460786017B638_inline(L_30, L_31, NULL);
		FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 L_32 = __this->___m_Reader;
		int32_t* L_33 = (int32_t*)(&__this->___NetworkTick);
		ByteUnpacker_ReadValueBitPacked_mC5142499F3BA1F4D8C60EDF335D6C54B0D78C4AC(L_32, L_33, NULL);
	}

IL_0110:
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_34 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_35 = L_34->___TrackByStateId;
		if (!L_35)
		{
			goto IL_0133;
		}
	}
	{
		int32_t* L_36 = (int32_t*)(&__this->___StateId);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_37 = V_3;
		BufferSerializer_1_SerializeValue_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m59AF230EB443B685CB322B5AA0898734756EADD7((&___0_serializer), L_36, L_37, NULL);
	}

IL_0133:
	{
		bool L_38;
		L_38 = NetworkTransformState_get_HasPositionChange_mF827577ABA451C60526B23885B255D1285B1FBBF_inline(__this, NULL);
		if (!L_38)
		{
			goto IL_02a2;
		}
	}
	{
		bool L_39;
		L_39 = NetworkTransformState_get_UseHalfFloatPrecision_m0513126B8151A8353AF0931D1E792F9E064C7FA8_inline(__this, NULL);
		if (!L_39)
		{
			goto IL_0248;
		}
	}
	{
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_40 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_41 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_42 = L_41->___SynchronizeBaseHalfFloat;
		L_40->___SynchronizeBase = L_42;
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_43 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_44 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&L_43->___HalfVector3);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_45 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_44->___AxisToSynchronize);
		bool L_46;
		L_46 = NetworkTransformState_get_HasPositionX_mC8E02257F7B924AF10C4E88A21C6DF55264A6451_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_45, 0, L_46, NULL);
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_47 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_48 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&L_47->___HalfVector3);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_49 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_48->___AxisToSynchronize);
		bool L_50;
		L_50 = NetworkTransformState_get_HasPositionY_mB77D3E22968FCB3B1F946A7F963E6AFABF915D89_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_49, 1, L_50, NULL);
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_51 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_52 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&L_51->___HalfVector3);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_53 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_52->___AxisToSynchronize);
		bool L_54;
		L_54 = NetworkTransformState_get_HasPositionZ_m3EB043B0EBA833E145F80474615FA82061165C9B_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_53, 2, L_54, NULL);
		bool L_55;
		L_55 = NetworkTransformState_get_IsTeleportingNextFrame_m7139315A1CE849C8DBB503EA4154E6D71582B254_inline(__this, NULL);
		if (!L_55)
		{
			goto IL_0217;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_56 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___CurrentPosition);
		BufferSerializer_1_SerializeValue_m0773DBBB39CFDB93D7DE224B29AA3E23DADF8D16((&___0_serializer), L_56, NULL);
		bool L_57;
		L_57 = NetworkTransformState_get_IsSynchronizing_m99FE076BE4E9D7AB6F7DAF16523F5B72027269EE_inline(__this, NULL);
		if (!L_57)
		{
			goto IL_02a2;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_58 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___DeltaPosition);
		BufferSerializer_1_SerializeValue_m0773DBBB39CFDB93D7DE224B29AA3E23DADF8D16((&___0_serializer), L_58, NULL);
		bool L_59 = V_1;
		if (L_59)
		{
			goto IL_0205;
		}
	}
	{
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_60 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		int32_t L_61 = __this->___NetworkTick;
		L_60->___NetworkTick = L_61;
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_62 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B L_63 = ___0_serializer;
		NetworkDeltaPosition_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_mEFF3CFDD8175C997D6164E5198B21F8664987407(L_62, L_63, NULL);
		goto IL_02a2;
	}

IL_0205:
	{
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_64 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		BufferSerializer_1_SerializeNetworkSerializable_TisNetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9_m86B6020E8E8853ACD5CA58B7EEB3913F7EE11A97((&___0_serializer), L_64, il2cpp_rgctx_method(method->rgctx_data, 7));
		goto IL_02a2;
	}

IL_0217:
	{
		bool L_65 = V_1;
		if (L_65)
		{
			goto IL_0239;
		}
	}
	{
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_66 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		int32_t L_67 = __this->___NetworkTick;
		L_66->___NetworkTick = L_67;
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_68 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B L_69 = ___0_serializer;
		NetworkDeltaPosition_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_mEFF3CFDD8175C997D6164E5198B21F8664987407(L_68, L_69, NULL);
		goto IL_02a2;
	}

IL_0239:
	{
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_70 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		BufferSerializer_1_SerializeNetworkSerializable_TisNetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9_m86B6020E8E8853ACD5CA58B7EEB3913F7EE11A97((&___0_serializer), L_70, il2cpp_rgctx_method(method->rgctx_data, 7));
		goto IL_02a2;
	}

IL_0248:
	{
		bool L_71;
		L_71 = NetworkTransformState_get_HasPositionX_mC8E02257F7B924AF10C4E88A21C6DF55264A6451_inline(__this, NULL);
		if (!L_71)
		{
			goto IL_0266;
		}
	}
	{
		float* L_72 = (float*)(&__this->___PositionX);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_73 = V_3;
		BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m6101B238F07953CE18E1F86F2233DEFF3CB93159((&___0_serializer), L_72, L_73, NULL);
	}

IL_0266:
	{
		bool L_74;
		L_74 = NetworkTransformState_get_HasPositionY_mB77D3E22968FCB3B1F946A7F963E6AFABF915D89_inline(__this, NULL);
		if (!L_74)
		{
			goto IL_0284;
		}
	}
	{
		float* L_75 = (float*)(&__this->___PositionY);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_76 = V_3;
		BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m6101B238F07953CE18E1F86F2233DEFF3CB93159((&___0_serializer), L_75, L_76, NULL);
	}

IL_0284:
	{
		bool L_77;
		L_77 = NetworkTransformState_get_HasPositionZ_m3EB043B0EBA833E145F80474615FA82061165C9B_inline(__this, NULL);
		if (!L_77)
		{
			goto IL_02a2;
		}
	}
	{
		float* L_78 = (float*)(&__this->___PositionZ);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_79 = V_3;
		BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m6101B238F07953CE18E1F86F2233DEFF3CB93159((&___0_serializer), L_78, L_79, NULL);
	}

IL_02a2:
	{
		bool L_80;
		L_80 = NetworkTransformState_get_HasRotAngleChange_m4D900826D7636E38F55B6BEDBD88A61230FEE50A_inline(__this, NULL);
		if (!L_80)
		{
			goto IL_04c2;
		}
	}
	{
		bool L_81;
		L_81 = NetworkTransformState_get_QuaternionSync_mBB94E4FD11175FD76DDF0EAEB0210E369F28C747_inline(__this, NULL);
		if (!L_81)
		{
			goto IL_0377;
		}
	}
	{
		bool L_82;
		L_82 = NetworkTransformState_get_IsTeleportingNextFrame_m7139315A1CE849C8DBB503EA4154E6D71582B254_inline(__this, NULL);
		if (!L_82)
		{
			goto IL_02d2;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_83 = (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*)(&__this->___Rotation);
		BufferSerializer_1_SerializeValue_mF8864064239A7820146C9482A6E1F7FE22607F81((&___0_serializer), L_83, NULL);
		goto IL_04c2;
	}

IL_02d2:
	{
		bool L_84;
		L_84 = NetworkTransformState_get_QuaternionCompression_m0473AF4A43B2923E5C2359643E3C7C68DEE6339B_inline(__this, NULL);
		if (!L_84)
		{
			goto IL_0320;
		}
	}
	{
		bool L_85 = V_1;
		if (!L_85)
		{
			goto IL_02ee;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_86 = (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*)(&__this->___Rotation);
		uint32_t L_87;
		L_87 = QuaternionCompressor_CompressQuaternion_mDFB8E04C1429D8183D314DAEA13E7725C0FADDAD_inline(L_86, NULL);
		__this->___QuaternionCompressed = L_87;
	}

IL_02ee:
	{
		uint32_t* L_88 = (uint32_t*)(&__this->___QuaternionCompressed);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_89 = V_3;
		BufferSerializer_1_SerializeValue_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_m175DEC7EA748331C16BF1972F3981E933059BE3A((&___0_serializer), L_88, L_89, NULL);
		bool L_90 = V_1;
		if (L_90)
		{
			goto IL_04c2;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_91 = (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*)(&__this->___Rotation);
		uint32_t L_92 = __this->___QuaternionCompressed;
		QuaternionCompressor_DecompressQuaternion_mDABA28208E32355842F5BFA792A08813DBE82F51_inline(L_91, L_92, NULL);
		goto IL_04c2;
	}

IL_0320:
	{
		bool L_93;
		L_93 = NetworkTransformState_get_UseHalfFloatPrecision_m0513126B8151A8353AF0931D1E792F9E064C7FA8_inline(__this, NULL);
		if (!L_93)
		{
			goto IL_0365;
		}
	}
	{
		bool L_94 = V_1;
		if (!L_94)
		{
			goto IL_033c;
		}
	}
	{
		HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD* L_95 = (HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD*)(&__this->___HalfVectorRotation);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_96 = (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*)(&__this->___Rotation);
		HalfVector4_UpdateFrom_m49F84D6FA68D9025729B9AE5BED74C42FC1C2A4D_inline(L_95, L_96, NULL);
	}

IL_033c:
	{
		HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD* L_97 = (HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD*)(&__this->___HalfVectorRotation);
		BufferSerializer_1_SerializeNetworkSerializable_TisHalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD_mC29BAD249B57B83497C2A1EFAD69D6E2A902F55D((&___0_serializer), L_97, il2cpp_rgctx_method(method->rgctx_data, 11));
		bool L_98 = V_1;
		if (L_98)
		{
			goto IL_04c2;
		}
	}
	{
		HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD* L_99 = (HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD*)(&__this->___HalfVectorRotation);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_100;
		L_100 = HalfVector4_ToQuaternion_m2A8121C41C193D8B2BE815FE6C741057B4BD85C5_inline(L_99, NULL);
		__this->___Rotation = L_100;
		goto IL_04c2;
	}

IL_0365:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_101 = (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*)(&__this->___Rotation);
		BufferSerializer_1_SerializeValue_mF8864064239A7820146C9482A6E1F7FE22607F81((&___0_serializer), L_101, NULL);
		goto IL_04c2;
	}

IL_0377:
	{
		bool L_102;
		L_102 = NetworkTransformState_get_UseHalfFloatPrecision_m0513126B8151A8353AF0931D1E792F9E064C7FA8_inline(__this, NULL);
		if (!L_102)
		{
			goto IL_0468;
		}
	}
	{
		bool L_103;
		L_103 = NetworkTransformState_get_IsTeleportingNextFrame_m7139315A1CE849C8DBB503EA4154E6D71582B254_inline(__this, NULL);
		if (L_103)
		{
			goto IL_0468;
		}
	}
	{
		bool L_104;
		L_104 = NetworkTransformState_get_HasRotAngleChange_m4D900826D7636E38F55B6BEDBD88A61230FEE50A_inline(__this, NULL);
		if (!L_104)
		{
			goto IL_04c2;
		}
	}
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_105 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfEulerRotation);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_106 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_105->___AxisToSynchronize);
		bool L_107;
		L_107 = NetworkTransformState_get_HasRotAngleX_m2017FDEB7C6355F80DCAD0258AA5486D6FBDC816_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_106, 0, L_107, NULL);
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_108 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfEulerRotation);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_109 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_108->___AxisToSynchronize);
		bool L_110;
		L_110 = NetworkTransformState_get_HasRotAngleY_m1D53E40810F158FDFEEAC32A1487E63ABC5CB040_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_109, 1, L_110, NULL);
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_111 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfEulerRotation);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_112 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_111->___AxisToSynchronize);
		bool L_113;
		L_113 = NetworkTransformState_get_HasRotAngleZ_m5B23DA8ED870129BF35C9A82B7776605C248DE04_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_112, 2, L_113, NULL);
		bool L_114 = V_1;
		if (!L_114)
		{
			goto IL_03fd;
		}
	}
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_115 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfEulerRotation);
		float L_116 = __this->___RotAngleX;
		float L_117 = __this->___RotAngleY;
		float L_118 = __this->___RotAngleZ;
		HalfVector3_Set_m442C051B289196D68C7B0C6C38ABBA71EADDADEA(L_115, L_116, L_117, L_118, NULL);
	}

IL_03fd:
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_119 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfEulerRotation);
		il2cpp_codegen_initobj((&V_4), sizeof(ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3));
		ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 L_120 = V_4;
		BufferSerializer_1_SerializeValue_TisHalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02_mAD61C61A65799B59048C11919A5C6FD17115B106((&___0_serializer), L_119, L_120, NULL);
		bool L_121 = V_1;
		if (L_121)
		{
			goto IL_04c2;
		}
	}
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_122 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfEulerRotation);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_123;
		L_123 = HalfVector3_ToVector3_m0D9B03E9618FA457A3A527E30AA765EB4093D0D1_inline(L_122, NULL);
		V_5 = L_123;
		bool L_124;
		L_124 = NetworkTransformState_get_HasRotAngleX_m2017FDEB7C6355F80DCAD0258AA5486D6FBDC816_inline(__this, NULL);
		if (!L_124)
		{
			goto IL_043c;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_125 = V_5;
		float L_126 = L_125.___x;
		__this->___RotAngleX = L_126;
	}

IL_043c:
	{
		bool L_127;
		L_127 = NetworkTransformState_get_HasRotAngleY_m1D53E40810F158FDFEEAC32A1487E63ABC5CB040_inline(__this, NULL);
		if (!L_127)
		{
			goto IL_0451;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_128 = V_5;
		float L_129 = L_128.___y;
		__this->___RotAngleY = L_129;
	}

IL_0451:
	{
		bool L_130;
		L_130 = NetworkTransformState_get_HasRotAngleZ_m5B23DA8ED870129BF35C9A82B7776605C248DE04_inline(__this, NULL);
		if (!L_130)
		{
			goto IL_04c2;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_131 = V_5;
		float L_132 = L_131.___z;
		__this->___RotAngleZ = L_132;
		goto IL_04c2;
	}

IL_0468:
	{
		bool L_133;
		L_133 = NetworkTransformState_get_HasRotAngleX_m2017FDEB7C6355F80DCAD0258AA5486D6FBDC816_inline(__this, NULL);
		if (!L_133)
		{
			goto IL_0486;
		}
	}
	{
		float* L_134 = (float*)(&__this->___RotAngleX);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_135 = V_3;
		BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m6101B238F07953CE18E1F86F2233DEFF3CB93159((&___0_serializer), L_134, L_135, NULL);
	}

IL_0486:
	{
		bool L_136;
		L_136 = NetworkTransformState_get_HasRotAngleY_m1D53E40810F158FDFEEAC32A1487E63ABC5CB040_inline(__this, NULL);
		if (!L_136)
		{
			goto IL_04a4;
		}
	}
	{
		float* L_137 = (float*)(&__this->___RotAngleY);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_138 = V_3;
		BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m6101B238F07953CE18E1F86F2233DEFF3CB93159((&___0_serializer), L_137, L_138, NULL);
	}

IL_04a4:
	{
		bool L_139;
		L_139 = NetworkTransformState_get_HasRotAngleZ_m5B23DA8ED870129BF35C9A82B7776605C248DE04_inline(__this, NULL);
		if (!L_139)
		{
			goto IL_04c2;
		}
	}
	{
		float* L_140 = (float*)(&__this->___RotAngleZ);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_141 = V_3;
		BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m6101B238F07953CE18E1F86F2233DEFF3CB93159((&___0_serializer), L_140, L_141, NULL);
	}

IL_04c2:
	{
		bool L_142;
		L_142 = NetworkTransformState_get_HasScaleChange_mD5FBA90EF892DC24F087B409A4A4F04178E955F7_inline(__this, NULL);
		if (!L_142)
		{
			goto IL_0660;
		}
	}
	{
		bool L_143;
		L_143 = NetworkTransformState_get_IsTeleportingNextFrame_m7139315A1CE849C8DBB503EA4154E6D71582B254_inline(__this, NULL);
		if (!L_143)
		{
			goto IL_04ef;
		}
	}
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_144 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_145 = L_144->___IsParented;
		if (!L_145)
		{
			goto IL_04ef;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_146 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___LossyScale);
		BufferSerializer_1_SerializeValue_m0773DBBB39CFDB93D7DE224B29AA3E23DADF8D16((&___0_serializer), L_146, NULL);
	}

IL_04ef:
	{
		bool L_147;
		L_147 = NetworkTransformState_get_UseHalfFloatPrecision_m0513126B8151A8353AF0931D1E792F9E064C7FA8_inline(__this, NULL);
		if (!L_147)
		{
			goto IL_0606;
		}
	}
	{
		bool L_148;
		L_148 = NetworkTransformState_get_IsTeleportingNextFrame_m7139315A1CE849C8DBB503EA4154E6D71582B254_inline(__this, NULL);
		if (!L_148)
		{
			goto IL_0514;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_149 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___Scale);
		BufferSerializer_1_SerializeValue_m0773DBBB39CFDB93D7DE224B29AA3E23DADF8D16((&___0_serializer), L_149, NULL);
		goto IL_0660;
	}

IL_0514:
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_150 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfVectorScale);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_151 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_150->___AxisToSynchronize);
		bool L_152;
		L_152 = NetworkTransformState_get_HasScaleX_m82B5E6E8FD2A17E31F8B4179124227E34D190756_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_151, 0, L_152, NULL);
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_153 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfVectorScale);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_154 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_153->___AxisToSynchronize);
		bool L_155;
		L_155 = NetworkTransformState_get_HasScaleY_mC709C18060AFD0D5944B749FAE96A82F8B078821_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_154, 1, L_155, NULL);
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_156 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfVectorScale);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_157 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_156->___AxisToSynchronize);
		bool L_158;
		L_158 = NetworkTransformState_get_HasScaleZ_m812D411158FC2B56DFE0BC3EA77A999220F52FD8_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_157, 2, L_158, NULL);
		bool L_159 = V_1;
		if (!L_159)
		{
			goto IL_058b;
		}
	}
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_160 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfVectorScale);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_161 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___Scale);
		float L_162;
		L_162 = Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_inline(L_161, 0, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_163 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___Scale);
		float L_164;
		L_164 = Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_inline(L_163, 1, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_165 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___Scale);
		float L_166;
		L_166 = Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_inline(L_165, 2, NULL);
		HalfVector3_Set_m442C051B289196D68C7B0C6C38ABBA71EADDADEA(L_160, L_162, L_164, L_166, NULL);
	}

IL_058b:
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_167 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfVectorScale);
		il2cpp_codegen_initobj((&V_4), sizeof(ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3));
		ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 L_168 = V_4;
		BufferSerializer_1_SerializeValue_TisHalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02_mAD61C61A65799B59048C11919A5C6FD17115B106((&___0_serializer), L_167, L_168, NULL);
		bool L_169 = V_1;
		if (L_169)
		{
			goto IL_0660;
		}
	}
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_170 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfVectorScale);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_171;
		L_171 = HalfVector3_ToVector3_m0D9B03E9618FA457A3A527E30AA765EB4093D0D1_inline(L_170, NULL);
		__this->___Scale = L_171;
		bool L_172;
		L_172 = NetworkTransformState_get_HasScaleX_m82B5E6E8FD2A17E31F8B4179124227E34D190756_inline(__this, NULL);
		if (!L_172)
		{
			goto IL_05d2;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_173 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___Scale);
		float L_174 = L_173->___x;
		__this->___ScaleX = L_174;
	}

IL_05d2:
	{
		bool L_175;
		L_175 = NetworkTransformState_get_HasScaleY_mC709C18060AFD0D5944B749FAE96A82F8B078821_inline(__this, NULL);
		if (!L_175)
		{
			goto IL_05eb;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_176 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___Scale);
		float L_177 = L_176->___y;
		__this->___ScaleY = L_177;
	}

IL_05eb:
	{
		bool L_178;
		L_178 = NetworkTransformState_get_HasScaleZ_m812D411158FC2B56DFE0BC3EA77A999220F52FD8_inline(__this, NULL);
		if (!L_178)
		{
			goto IL_0660;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_179 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___Scale);
		float L_180 = L_179->___x;
		__this->___ScaleZ = L_180;
		goto IL_0660;
	}

IL_0606:
	{
		bool L_181;
		L_181 = NetworkTransformState_get_HasScaleX_m82B5E6E8FD2A17E31F8B4179124227E34D190756_inline(__this, NULL);
		if (!L_181)
		{
			goto IL_0624;
		}
	}
	{
		float* L_182 = (float*)(&__this->___ScaleX);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_183 = V_3;
		BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m6101B238F07953CE18E1F86F2233DEFF3CB93159((&___0_serializer), L_182, L_183, NULL);
	}

IL_0624:
	{
		bool L_184;
		L_184 = NetworkTransformState_get_HasScaleY_mC709C18060AFD0D5944B749FAE96A82F8B078821_inline(__this, NULL);
		if (!L_184)
		{
			goto IL_0642;
		}
	}
	{
		float* L_185 = (float*)(&__this->___ScaleY);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_186 = V_3;
		BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m6101B238F07953CE18E1F86F2233DEFF3CB93159((&___0_serializer), L_185, L_186, NULL);
	}

IL_0642:
	{
		bool L_187;
		L_187 = NetworkTransformState_get_HasScaleZ_m812D411158FC2B56DFE0BC3EA77A999220F52FD8_inline(__this, NULL);
		if (!L_187)
		{
			goto IL_0660;
		}
	}
	{
		float* L_188 = (float*)(&__this->___ScaleZ);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_189 = V_3;
		BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m6101B238F07953CE18E1F86F2233DEFF3CB93159((&___0_serializer), L_188, L_189, NULL);
	}

IL_0660:
	{
		bool L_190 = V_1;
		if (L_190)
		{
			goto IL_069b;
		}
	}
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_191 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_192;
		L_192 = NetworkTransformState_get_HasPositionChange_mF827577ABA451C60526B23885B255D1285B1FBBF_inline(__this, NULL);
		if (L_192)
		{
			G_B92_0 = L_191;
			goto IL_0681;
		}
		G_B90_0 = L_191;
	}
	{
		bool L_193;
		L_193 = NetworkTransformState_get_HasRotAngleChange_m4D900826D7636E38F55B6BEDBD88A61230FEE50A_inline(__this, NULL);
		if (L_193)
		{
			G_B92_0 = G_B90_0;
			goto IL_0681;
		}
		G_B91_0 = G_B90_0;
	}
	{
		bool L_194;
		L_194 = NetworkTransformState_get_HasScaleChange_mD5FBA90EF892DC24F087B409A4A4F04178E955F7_inline(__this, NULL);
		G_B93_0 = ((int32_t)(L_194));
		G_B93_1 = G_B91_0;
		goto IL_0682;
	}

IL_0681:
	{
		G_B93_0 = 1;
		G_B93_1 = G_B92_0;
	}

IL_0682:
	{
		G_B93_1->___IsDirty = (bool)G_B93_0;
		FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99* L_195 = (FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99*)(&__this->___m_Reader);
		int32_t L_196;
		L_196 = FastBufferReader_get_Position_m6B9DC9ECC9F2D943EA0103248E10AB9B95C8F4CF_inline(L_195, NULL);
		int32_t L_197 = V_0;
		NetworkTransformState_set_LastSerializedSize_m495ABA7CDD6AC0B7900EF02669F839F002427BF2_inline(__this, ((int32_t)il2cpp_codegen_subtract(L_196, L_197)), NULL);
		return;
	}

IL_069b:
	{
		FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC* L_198 = (FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC*)(&__this->___m_Writer);
		CHECKED_LOCAL_INIT(FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC_StaticInit,(FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		int32_t L_199;
		L_199 = FastBufferWriter_get_Position_m87642B5268B41B7D15D4E628DF93A5B5776A4B05_inline(L_198, NULL);
		int32_t L_200 = V_0;
		NetworkTransformState_set_LastSerializedSize_m495ABA7CDD6AC0B7900EF02669F839F002427BF2_inline(__this, ((int32_t)il2cpp_codegen_subtract(L_199, L_200)), NULL);
		return;
	}
}
IL2CPP_EXTERN_C  void NetworkTransformState_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_m315FE7B6046C0603C6C2F4904F76DDE868D9E59F_AdjustorThunk (RuntimeObject* __this, BufferSerializer_1_t8B54D07A3EDD3D37E1369C511353FC3344A0FF3B ___0_serializer, const RuntimeMethod* method)
{
	NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* _thisAdjusted;
	_thisAdjusted = il2cpp_codegen_get_raw_data<NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED>(__this);
	NetworkTransformState_NetworkSerialize_TisBufferSerializerReader_t821F6D93FEA6652401EA14C2C96FB7328355A091_m315FE7B6046C0603C6C2F4904F76DDE868D9E59F(_thisAdjusted, ___0_serializer, method);
}
// Method Definition Index: 70454
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetworkTransformState_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m1D7D00149B9F8D0C238E26F460829DA7CB811511 (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0 ___0_serializer, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	CHECKED_LOCAL(FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC_StaticInit);
	//<source_info:<no-source>:1>
	int32_t V_0 = 0;
	bool V_1 = false;
	uint32_t V_2 = 0;
	ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 V_3;
	memset((&V_3), 0, sizeof(V_3));
	ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 V_4;
	memset((&V_4), 0, sizeof(V_4));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_5;
	memset((&V_5), 0, sizeof(V_5));
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B92_0 = NULL;
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B90_0 = NULL;
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B91_0 = NULL;
	int32_t G_B93_0 = 0;
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B93_1 = NULL;
	{
		V_0 = 0;
		bool L_0;
		L_0 = BufferSerializer_1_get_IsWriter_mA81CADE3680B019327BD43C92F4743B2140A83EB((&___0_serializer), NULL);
		V_1 = L_0;
		bool L_1 = V_1;
		if (!L_1)
		{
			goto IL_0028;
		}
	}
	{
		FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC L_2;
		L_2 = BufferSerializer_1_GetFastBufferWriter_m0EDCCFEDDC0A291D14ACA9BB1DA18CD0ABAD9C60((&___0_serializer), NULL);
		__this->___m_Writer = L_2;
		FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC* L_3 = (FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC*)(&__this->___m_Writer);
		CHECKED_LOCAL_INIT(FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC_StaticInit,(FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		int32_t L_4;
		L_4 = FastBufferWriter_get_Position_m87642B5268B41B7D15D4E628DF93A5B5776A4B05_inline(L_3, NULL);
		V_0 = L_4;
		goto IL_0041;
	}

IL_0028:
	{
		FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 L_5;
		L_5 = BufferSerializer_1_GetFastBufferReader_mBE4915BC31492038A896F4FE19E6A1D815815171((&___0_serializer), NULL);
		__this->___m_Reader = L_5;
		FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99* L_6 = (FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99*)(&__this->___m_Reader);
		int32_t L_7;
		L_7 = FastBufferReader_get_Position_m6B9DC9ECC9F2D943EA0103248E10AB9B95C8F4CF_inline(L_6, NULL);
		V_0 = L_7;
	}

IL_0041:
	{
		bool L_8 = V_1;
		if (!L_8)
		{
			goto IL_00e6;
		}
	}
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_9 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_10 = L_9->___UseUnreliableDeltas;
		if (!L_10)
		{
			goto IL_00b1;
		}
	}
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_11 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_12 = L_11->___IsTeleportingNextFrame;
		if (L_12)
		{
			goto IL_0095;
		}
	}
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_13 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_14 = L_13->___IsSynchronizing;
		if (L_14)
		{
			goto IL_0095;
		}
	}
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_15 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_16 = L_15->___UnreliableFrameSync;
		if (L_16)
		{
			goto IL_0095;
		}
	}
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_17 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_18 = L_17->___UseHalfFloatPrecision;
		if (!L_18)
		{
			goto IL_00a3;
		}
	}
	{
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_19 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		bool L_20 = L_19->___CollapsedDeltaIntoBase;
		if (!L_20)
		{
			goto IL_00a3;
		}
	}

IL_0095:
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_21 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		L_21->___ReliableSequenced = (bool)1;
		goto IL_00bd;
	}

IL_00a3:
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_22 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		L_22->___ReliableSequenced = (bool)0;
		goto IL_00bd;
	}

IL_00b1:
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_23 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		L_23->___ReliableSequenced = (bool)1;
	}

IL_00bd:
	{
		FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC L_24 = __this->___m_Writer;
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_25 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		uint32_t L_26;
		L_26 = FlagStates_GetBitsetRepresentation_m7002081C4C5BD54947BD04940B1FA592C83CEC3B_inline(L_25, NULL);
		BytePacker_WriteValueBitPacked_m50033FEA83560CA7AF9668B3C7352E013D518F11(L_24, L_26, NULL);
		FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC L_27 = __this->___m_Writer;
		int32_t L_28 = __this->___NetworkTick;
		BytePacker_WriteValueBitPacked_m510F6322BA0F2C85AF9527A7927FF9B03F0AE613(L_27, L_28, NULL);
		goto IL_0110;
	}

IL_00e6:
	{
		FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 L_29 = __this->___m_Reader;
		ByteUnpacker_ReadValueBitPacked_mACA5F48002EFB41F31DB0F4AAB4936A2E423DCA4(L_29, (&V_2), NULL);
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_30 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		uint32_t L_31 = V_2;
		FlagStates_SetStateFromBitset_m88B26BC623EA70281C6F7A973DC460786017B638_inline(L_30, L_31, NULL);
		FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 L_32 = __this->___m_Reader;
		int32_t* L_33 = (int32_t*)(&__this->___NetworkTick);
		ByteUnpacker_ReadValueBitPacked_mC5142499F3BA1F4D8C60EDF335D6C54B0D78C4AC(L_32, L_33, NULL);
	}

IL_0110:
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_34 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_35 = L_34->___TrackByStateId;
		if (!L_35)
		{
			goto IL_0133;
		}
	}
	{
		int32_t* L_36 = (int32_t*)(&__this->___StateId);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_37 = V_3;
		BufferSerializer_1_SerializeValue_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m77A3B1A6805879DFC74A55FBE9F076C81CF22869((&___0_serializer), L_36, L_37, NULL);
	}

IL_0133:
	{
		bool L_38;
		L_38 = NetworkTransformState_get_HasPositionChange_mF827577ABA451C60526B23885B255D1285B1FBBF_inline(__this, NULL);
		if (!L_38)
		{
			goto IL_02a2;
		}
	}
	{
		bool L_39;
		L_39 = NetworkTransformState_get_UseHalfFloatPrecision_m0513126B8151A8353AF0931D1E792F9E064C7FA8_inline(__this, NULL);
		if (!L_39)
		{
			goto IL_0248;
		}
	}
	{
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_40 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_41 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_42 = L_41->___SynchronizeBaseHalfFloat;
		L_40->___SynchronizeBase = L_42;
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_43 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_44 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&L_43->___HalfVector3);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_45 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_44->___AxisToSynchronize);
		bool L_46;
		L_46 = NetworkTransformState_get_HasPositionX_mC8E02257F7B924AF10C4E88A21C6DF55264A6451_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_45, 0, L_46, NULL);
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_47 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_48 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&L_47->___HalfVector3);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_49 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_48->___AxisToSynchronize);
		bool L_50;
		L_50 = NetworkTransformState_get_HasPositionY_mB77D3E22968FCB3B1F946A7F963E6AFABF915D89_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_49, 1, L_50, NULL);
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_51 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_52 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&L_51->___HalfVector3);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_53 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_52->___AxisToSynchronize);
		bool L_54;
		L_54 = NetworkTransformState_get_HasPositionZ_m3EB043B0EBA833E145F80474615FA82061165C9B_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_53, 2, L_54, NULL);
		bool L_55;
		L_55 = NetworkTransformState_get_IsTeleportingNextFrame_m7139315A1CE849C8DBB503EA4154E6D71582B254_inline(__this, NULL);
		if (!L_55)
		{
			goto IL_0217;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_56 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___CurrentPosition);
		BufferSerializer_1_SerializeValue_m0364BE9DADF6A928C2E671E4712E0E74660342D6((&___0_serializer), L_56, NULL);
		bool L_57;
		L_57 = NetworkTransformState_get_IsSynchronizing_m99FE076BE4E9D7AB6F7DAF16523F5B72027269EE_inline(__this, NULL);
		if (!L_57)
		{
			goto IL_02a2;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_58 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___DeltaPosition);
		BufferSerializer_1_SerializeValue_m0364BE9DADF6A928C2E671E4712E0E74660342D6((&___0_serializer), L_58, NULL);
		bool L_59 = V_1;
		if (L_59)
		{
			goto IL_0205;
		}
	}
	{
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_60 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		int32_t L_61 = __this->___NetworkTick;
		L_60->___NetworkTick = L_61;
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_62 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0 L_63 = ___0_serializer;
		NetworkDeltaPosition_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m30FDAAF063DE71B8F7846DA81B669D88BE18CDBB(L_62, L_63, NULL);
		goto IL_02a2;
	}

IL_0205:
	{
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_64 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		BufferSerializer_1_SerializeNetworkSerializable_TisNetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9_mB135731E72075A1E8F5F62A67D8A5CC317474852((&___0_serializer), L_64, NULL);
		goto IL_02a2;
	}

IL_0217:
	{
		bool L_65 = V_1;
		if (L_65)
		{
			goto IL_0239;
		}
	}
	{
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_66 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		int32_t L_67 = __this->___NetworkTick;
		L_66->___NetworkTick = L_67;
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_68 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0 L_69 = ___0_serializer;
		NetworkDeltaPosition_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m30FDAAF063DE71B8F7846DA81B669D88BE18CDBB(L_68, L_69, NULL);
		goto IL_02a2;
	}

IL_0239:
	{
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_70 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		BufferSerializer_1_SerializeNetworkSerializable_TisNetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9_mB135731E72075A1E8F5F62A67D8A5CC317474852((&___0_serializer), L_70, NULL);
		goto IL_02a2;
	}

IL_0248:
	{
		bool L_71;
		L_71 = NetworkTransformState_get_HasPositionX_mC8E02257F7B924AF10C4E88A21C6DF55264A6451_inline(__this, NULL);
		if (!L_71)
		{
			goto IL_0266;
		}
	}
	{
		float* L_72 = (float*)(&__this->___PositionX);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_73 = V_3;
		BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m27B1CE4986F8F5797956E336EDF7FF730AB613E4((&___0_serializer), L_72, L_73, NULL);
	}

IL_0266:
	{
		bool L_74;
		L_74 = NetworkTransformState_get_HasPositionY_mB77D3E22968FCB3B1F946A7F963E6AFABF915D89_inline(__this, NULL);
		if (!L_74)
		{
			goto IL_0284;
		}
	}
	{
		float* L_75 = (float*)(&__this->___PositionY);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_76 = V_3;
		BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m27B1CE4986F8F5797956E336EDF7FF730AB613E4((&___0_serializer), L_75, L_76, NULL);
	}

IL_0284:
	{
		bool L_77;
		L_77 = NetworkTransformState_get_HasPositionZ_m3EB043B0EBA833E145F80474615FA82061165C9B_inline(__this, NULL);
		if (!L_77)
		{
			goto IL_02a2;
		}
	}
	{
		float* L_78 = (float*)(&__this->___PositionZ);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_79 = V_3;
		BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m27B1CE4986F8F5797956E336EDF7FF730AB613E4((&___0_serializer), L_78, L_79, NULL);
	}

IL_02a2:
	{
		bool L_80;
		L_80 = NetworkTransformState_get_HasRotAngleChange_m4D900826D7636E38F55B6BEDBD88A61230FEE50A_inline(__this, NULL);
		if (!L_80)
		{
			goto IL_04c2;
		}
	}
	{
		bool L_81;
		L_81 = NetworkTransformState_get_QuaternionSync_mBB94E4FD11175FD76DDF0EAEB0210E369F28C747_inline(__this, NULL);
		if (!L_81)
		{
			goto IL_0377;
		}
	}
	{
		bool L_82;
		L_82 = NetworkTransformState_get_IsTeleportingNextFrame_m7139315A1CE849C8DBB503EA4154E6D71582B254_inline(__this, NULL);
		if (!L_82)
		{
			goto IL_02d2;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_83 = (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*)(&__this->___Rotation);
		BufferSerializer_1_SerializeValue_m5703B125C4DB4384D52002A802AB88FA88E27331((&___0_serializer), L_83, NULL);
		goto IL_04c2;
	}

IL_02d2:
	{
		bool L_84;
		L_84 = NetworkTransformState_get_QuaternionCompression_m0473AF4A43B2923E5C2359643E3C7C68DEE6339B_inline(__this, NULL);
		if (!L_84)
		{
			goto IL_0320;
		}
	}
	{
		bool L_85 = V_1;
		if (!L_85)
		{
			goto IL_02ee;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_86 = (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*)(&__this->___Rotation);
		uint32_t L_87;
		L_87 = QuaternionCompressor_CompressQuaternion_mDFB8E04C1429D8183D314DAEA13E7725C0FADDAD_inline(L_86, NULL);
		__this->___QuaternionCompressed = L_87;
	}

IL_02ee:
	{
		uint32_t* L_88 = (uint32_t*)(&__this->___QuaternionCompressed);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_89 = V_3;
		BufferSerializer_1_SerializeValue_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_m6F6DFB50403FF15EAF7B88A883C1739AE9E6900B((&___0_serializer), L_88, L_89, NULL);
		bool L_90 = V_1;
		if (L_90)
		{
			goto IL_04c2;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_91 = (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*)(&__this->___Rotation);
		uint32_t L_92 = __this->___QuaternionCompressed;
		QuaternionCompressor_DecompressQuaternion_mDABA28208E32355842F5BFA792A08813DBE82F51_inline(L_91, L_92, NULL);
		goto IL_04c2;
	}

IL_0320:
	{
		bool L_93;
		L_93 = NetworkTransformState_get_UseHalfFloatPrecision_m0513126B8151A8353AF0931D1E792F9E064C7FA8_inline(__this, NULL);
		if (!L_93)
		{
			goto IL_0365;
		}
	}
	{
		bool L_94 = V_1;
		if (!L_94)
		{
			goto IL_033c;
		}
	}
	{
		HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD* L_95 = (HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD*)(&__this->___HalfVectorRotation);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_96 = (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*)(&__this->___Rotation);
		HalfVector4_UpdateFrom_m49F84D6FA68D9025729B9AE5BED74C42FC1C2A4D_inline(L_95, L_96, NULL);
	}

IL_033c:
	{
		HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD* L_97 = (HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD*)(&__this->___HalfVectorRotation);
		BufferSerializer_1_SerializeNetworkSerializable_TisHalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD_m3EAD438E8EC22446E2CAF3F94F16058FB339A67C((&___0_serializer), L_97, NULL);
		bool L_98 = V_1;
		if (L_98)
		{
			goto IL_04c2;
		}
	}
	{
		HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD* L_99 = (HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD*)(&__this->___HalfVectorRotation);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_100;
		L_100 = HalfVector4_ToQuaternion_m2A8121C41C193D8B2BE815FE6C741057B4BD85C5_inline(L_99, NULL);
		__this->___Rotation = L_100;
		goto IL_04c2;
	}

IL_0365:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_101 = (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*)(&__this->___Rotation);
		BufferSerializer_1_SerializeValue_m5703B125C4DB4384D52002A802AB88FA88E27331((&___0_serializer), L_101, NULL);
		goto IL_04c2;
	}

IL_0377:
	{
		bool L_102;
		L_102 = NetworkTransformState_get_UseHalfFloatPrecision_m0513126B8151A8353AF0931D1E792F9E064C7FA8_inline(__this, NULL);
		if (!L_102)
		{
			goto IL_0468;
		}
	}
	{
		bool L_103;
		L_103 = NetworkTransformState_get_IsTeleportingNextFrame_m7139315A1CE849C8DBB503EA4154E6D71582B254_inline(__this, NULL);
		if (L_103)
		{
			goto IL_0468;
		}
	}
	{
		bool L_104;
		L_104 = NetworkTransformState_get_HasRotAngleChange_m4D900826D7636E38F55B6BEDBD88A61230FEE50A_inline(__this, NULL);
		if (!L_104)
		{
			goto IL_04c2;
		}
	}
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_105 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfEulerRotation);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_106 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_105->___AxisToSynchronize);
		bool L_107;
		L_107 = NetworkTransformState_get_HasRotAngleX_m2017FDEB7C6355F80DCAD0258AA5486D6FBDC816_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_106, 0, L_107, NULL);
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_108 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfEulerRotation);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_109 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_108->___AxisToSynchronize);
		bool L_110;
		L_110 = NetworkTransformState_get_HasRotAngleY_m1D53E40810F158FDFEEAC32A1487E63ABC5CB040_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_109, 1, L_110, NULL);
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_111 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfEulerRotation);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_112 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_111->___AxisToSynchronize);
		bool L_113;
		L_113 = NetworkTransformState_get_HasRotAngleZ_m5B23DA8ED870129BF35C9A82B7776605C248DE04_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_112, 2, L_113, NULL);
		bool L_114 = V_1;
		if (!L_114)
		{
			goto IL_03fd;
		}
	}
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_115 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfEulerRotation);
		float L_116 = __this->___RotAngleX;
		float L_117 = __this->___RotAngleY;
		float L_118 = __this->___RotAngleZ;
		HalfVector3_Set_m442C051B289196D68C7B0C6C38ABBA71EADDADEA(L_115, L_116, L_117, L_118, NULL);
	}

IL_03fd:
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_119 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfEulerRotation);
		il2cpp_codegen_initobj((&V_4), sizeof(ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3));
		ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 L_120 = V_4;
		BufferSerializer_1_SerializeValue_TisHalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02_mF16FD9701D269D224C92C0ED1E0D19F34B152CC2((&___0_serializer), L_119, L_120, NULL);
		bool L_121 = V_1;
		if (L_121)
		{
			goto IL_04c2;
		}
	}
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_122 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfEulerRotation);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_123;
		L_123 = HalfVector3_ToVector3_m0D9B03E9618FA457A3A527E30AA765EB4093D0D1_inline(L_122, NULL);
		V_5 = L_123;
		bool L_124;
		L_124 = NetworkTransformState_get_HasRotAngleX_m2017FDEB7C6355F80DCAD0258AA5486D6FBDC816_inline(__this, NULL);
		if (!L_124)
		{
			goto IL_043c;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_125 = V_5;
		float L_126 = L_125.___x;
		__this->___RotAngleX = L_126;
	}

IL_043c:
	{
		bool L_127;
		L_127 = NetworkTransformState_get_HasRotAngleY_m1D53E40810F158FDFEEAC32A1487E63ABC5CB040_inline(__this, NULL);
		if (!L_127)
		{
			goto IL_0451;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_128 = V_5;
		float L_129 = L_128.___y;
		__this->___RotAngleY = L_129;
	}

IL_0451:
	{
		bool L_130;
		L_130 = NetworkTransformState_get_HasRotAngleZ_m5B23DA8ED870129BF35C9A82B7776605C248DE04_inline(__this, NULL);
		if (!L_130)
		{
			goto IL_04c2;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_131 = V_5;
		float L_132 = L_131.___z;
		__this->___RotAngleZ = L_132;
		goto IL_04c2;
	}

IL_0468:
	{
		bool L_133;
		L_133 = NetworkTransformState_get_HasRotAngleX_m2017FDEB7C6355F80DCAD0258AA5486D6FBDC816_inline(__this, NULL);
		if (!L_133)
		{
			goto IL_0486;
		}
	}
	{
		float* L_134 = (float*)(&__this->___RotAngleX);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_135 = V_3;
		BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m27B1CE4986F8F5797956E336EDF7FF730AB613E4((&___0_serializer), L_134, L_135, NULL);
	}

IL_0486:
	{
		bool L_136;
		L_136 = NetworkTransformState_get_HasRotAngleY_m1D53E40810F158FDFEEAC32A1487E63ABC5CB040_inline(__this, NULL);
		if (!L_136)
		{
			goto IL_04a4;
		}
	}
	{
		float* L_137 = (float*)(&__this->___RotAngleY);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_138 = V_3;
		BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m27B1CE4986F8F5797956E336EDF7FF730AB613E4((&___0_serializer), L_137, L_138, NULL);
	}

IL_04a4:
	{
		bool L_139;
		L_139 = NetworkTransformState_get_HasRotAngleZ_m5B23DA8ED870129BF35C9A82B7776605C248DE04_inline(__this, NULL);
		if (!L_139)
		{
			goto IL_04c2;
		}
	}
	{
		float* L_140 = (float*)(&__this->___RotAngleZ);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_141 = V_3;
		BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m27B1CE4986F8F5797956E336EDF7FF730AB613E4((&___0_serializer), L_140, L_141, NULL);
	}

IL_04c2:
	{
		bool L_142;
		L_142 = NetworkTransformState_get_HasScaleChange_mD5FBA90EF892DC24F087B409A4A4F04178E955F7_inline(__this, NULL);
		if (!L_142)
		{
			goto IL_0660;
		}
	}
	{
		bool L_143;
		L_143 = NetworkTransformState_get_IsTeleportingNextFrame_m7139315A1CE849C8DBB503EA4154E6D71582B254_inline(__this, NULL);
		if (!L_143)
		{
			goto IL_04ef;
		}
	}
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_144 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_145 = L_144->___IsParented;
		if (!L_145)
		{
			goto IL_04ef;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_146 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___LossyScale);
		BufferSerializer_1_SerializeValue_m0364BE9DADF6A928C2E671E4712E0E74660342D6((&___0_serializer), L_146, NULL);
	}

IL_04ef:
	{
		bool L_147;
		L_147 = NetworkTransformState_get_UseHalfFloatPrecision_m0513126B8151A8353AF0931D1E792F9E064C7FA8_inline(__this, NULL);
		if (!L_147)
		{
			goto IL_0606;
		}
	}
	{
		bool L_148;
		L_148 = NetworkTransformState_get_IsTeleportingNextFrame_m7139315A1CE849C8DBB503EA4154E6D71582B254_inline(__this, NULL);
		if (!L_148)
		{
			goto IL_0514;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_149 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___Scale);
		BufferSerializer_1_SerializeValue_m0364BE9DADF6A928C2E671E4712E0E74660342D6((&___0_serializer), L_149, NULL);
		goto IL_0660;
	}

IL_0514:
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_150 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfVectorScale);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_151 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_150->___AxisToSynchronize);
		bool L_152;
		L_152 = NetworkTransformState_get_HasScaleX_m82B5E6E8FD2A17E31F8B4179124227E34D190756_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_151, 0, L_152, NULL);
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_153 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfVectorScale);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_154 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_153->___AxisToSynchronize);
		bool L_155;
		L_155 = NetworkTransformState_get_HasScaleY_mC709C18060AFD0D5944B749FAE96A82F8B078821_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_154, 1, L_155, NULL);
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_156 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfVectorScale);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_157 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_156->___AxisToSynchronize);
		bool L_158;
		L_158 = NetworkTransformState_get_HasScaleZ_m812D411158FC2B56DFE0BC3EA77A999220F52FD8_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_157, 2, L_158, NULL);
		bool L_159 = V_1;
		if (!L_159)
		{
			goto IL_058b;
		}
	}
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_160 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfVectorScale);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_161 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___Scale);
		float L_162;
		L_162 = Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_inline(L_161, 0, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_163 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___Scale);
		float L_164;
		L_164 = Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_inline(L_163, 1, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_165 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___Scale);
		float L_166;
		L_166 = Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_inline(L_165, 2, NULL);
		HalfVector3_Set_m442C051B289196D68C7B0C6C38ABBA71EADDADEA(L_160, L_162, L_164, L_166, NULL);
	}

IL_058b:
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_167 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfVectorScale);
		il2cpp_codegen_initobj((&V_4), sizeof(ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3));
		ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 L_168 = V_4;
		BufferSerializer_1_SerializeValue_TisHalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02_mF16FD9701D269D224C92C0ED1E0D19F34B152CC2((&___0_serializer), L_167, L_168, NULL);
		bool L_169 = V_1;
		if (L_169)
		{
			goto IL_0660;
		}
	}
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_170 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfVectorScale);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_171;
		L_171 = HalfVector3_ToVector3_m0D9B03E9618FA457A3A527E30AA765EB4093D0D1_inline(L_170, NULL);
		__this->___Scale = L_171;
		bool L_172;
		L_172 = NetworkTransformState_get_HasScaleX_m82B5E6E8FD2A17E31F8B4179124227E34D190756_inline(__this, NULL);
		if (!L_172)
		{
			goto IL_05d2;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_173 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___Scale);
		float L_174 = L_173->___x;
		__this->___ScaleX = L_174;
	}

IL_05d2:
	{
		bool L_175;
		L_175 = NetworkTransformState_get_HasScaleY_mC709C18060AFD0D5944B749FAE96A82F8B078821_inline(__this, NULL);
		if (!L_175)
		{
			goto IL_05eb;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_176 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___Scale);
		float L_177 = L_176->___y;
		__this->___ScaleY = L_177;
	}

IL_05eb:
	{
		bool L_178;
		L_178 = NetworkTransformState_get_HasScaleZ_m812D411158FC2B56DFE0BC3EA77A999220F52FD8_inline(__this, NULL);
		if (!L_178)
		{
			goto IL_0660;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_179 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___Scale);
		float L_180 = L_179->___x;
		__this->___ScaleZ = L_180;
		goto IL_0660;
	}

IL_0606:
	{
		bool L_181;
		L_181 = NetworkTransformState_get_HasScaleX_m82B5E6E8FD2A17E31F8B4179124227E34D190756_inline(__this, NULL);
		if (!L_181)
		{
			goto IL_0624;
		}
	}
	{
		float* L_182 = (float*)(&__this->___ScaleX);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_183 = V_3;
		BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m27B1CE4986F8F5797956E336EDF7FF730AB613E4((&___0_serializer), L_182, L_183, NULL);
	}

IL_0624:
	{
		bool L_184;
		L_184 = NetworkTransformState_get_HasScaleY_mC709C18060AFD0D5944B749FAE96A82F8B078821_inline(__this, NULL);
		if (!L_184)
		{
			goto IL_0642;
		}
	}
	{
		float* L_185 = (float*)(&__this->___ScaleY);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_186 = V_3;
		BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m27B1CE4986F8F5797956E336EDF7FF730AB613E4((&___0_serializer), L_185, L_186, NULL);
	}

IL_0642:
	{
		bool L_187;
		L_187 = NetworkTransformState_get_HasScaleZ_m812D411158FC2B56DFE0BC3EA77A999220F52FD8_inline(__this, NULL);
		if (!L_187)
		{
			goto IL_0660;
		}
	}
	{
		float* L_188 = (float*)(&__this->___ScaleZ);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_189 = V_3;
		BufferSerializer_1_SerializeValue_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_m27B1CE4986F8F5797956E336EDF7FF730AB613E4((&___0_serializer), L_188, L_189, NULL);
	}

IL_0660:
	{
		bool L_190 = V_1;
		if (L_190)
		{
			goto IL_069b;
		}
	}
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_191 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_192;
		L_192 = NetworkTransformState_get_HasPositionChange_mF827577ABA451C60526B23885B255D1285B1FBBF_inline(__this, NULL);
		if (L_192)
		{
			G_B92_0 = L_191;
			goto IL_0681;
		}
		G_B90_0 = L_191;
	}
	{
		bool L_193;
		L_193 = NetworkTransformState_get_HasRotAngleChange_m4D900826D7636E38F55B6BEDBD88A61230FEE50A_inline(__this, NULL);
		if (L_193)
		{
			G_B92_0 = G_B90_0;
			goto IL_0681;
		}
		G_B91_0 = G_B90_0;
	}
	{
		bool L_194;
		L_194 = NetworkTransformState_get_HasScaleChange_mD5FBA90EF892DC24F087B409A4A4F04178E955F7_inline(__this, NULL);
		G_B93_0 = ((int32_t)(L_194));
		G_B93_1 = G_B91_0;
		goto IL_0682;
	}

IL_0681:
	{
		G_B93_0 = 1;
		G_B93_1 = G_B92_0;
	}

IL_0682:
	{
		G_B93_1->___IsDirty = (bool)G_B93_0;
		FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99* L_195 = (FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99*)(&__this->___m_Reader);
		int32_t L_196;
		L_196 = FastBufferReader_get_Position_m6B9DC9ECC9F2D943EA0103248E10AB9B95C8F4CF_inline(L_195, NULL);
		int32_t L_197 = V_0;
		NetworkTransformState_set_LastSerializedSize_m495ABA7CDD6AC0B7900EF02669F839F002427BF2_inline(__this, ((int32_t)il2cpp_codegen_subtract(L_196, L_197)), NULL);
		return;
	}

IL_069b:
	{
		FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC* L_198 = (FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC*)(&__this->___m_Writer);
		CHECKED_LOCAL_INIT(FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC_StaticInit,(FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		int32_t L_199;
		L_199 = FastBufferWriter_get_Position_m87642B5268B41B7D15D4E628DF93A5B5776A4B05_inline(L_198, NULL);
		int32_t L_200 = V_0;
		NetworkTransformState_set_LastSerializedSize_m495ABA7CDD6AC0B7900EF02669F839F002427BF2_inline(__this, ((int32_t)il2cpp_codegen_subtract(L_199, L_200)), NULL);
		return;
	}
}
IL2CPP_EXTERN_C  void NetworkTransformState_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m1D7D00149B9F8D0C238E26F460829DA7CB811511_AdjustorThunk (RuntimeObject* __this, BufferSerializer_1_tB07CC05C8821999D2912FC2880FC1CAF4094FEF0 ___0_serializer, const RuntimeMethod* method)
{
	NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* _thisAdjusted;
	_thisAdjusted = il2cpp_codegen_get_raw_data<NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED>(__this);
	NetworkTransformState_NetworkSerialize_TisBufferSerializerWriter_t3F287564BDCF264BABBB18BF4D541A95238FBFD4_m1D7D00149B9F8D0C238E26F460829DA7CB811511(_thisAdjusted, ___0_serializer, method);
}
// Method Definition Index: 70454
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetworkTransformState_NetworkSerialize_TisIl2CppFullySharedGenericAny_mCF668FDFEBE2180BB40C932053267AF2F816687C_fshared (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 ___0_serializer, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC_StaticInit);
	const uint32_t SizeOf_BufferSerializer_1_t1869AF78A7B65A1901809CB66D3F187CB0BD7F14 = il2cpp_codegen_sizeof(il2cpp_rgctx_data(method->rgctx_data, 0));
	const BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 L_63 = alloca(SizeOf_BufferSerializer_1_t1869AF78A7B65A1901809CB66D3F187CB0BD7F14);
	const BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 L_69 = L_63;
	//<source_info:<no-source>:1>
	int32_t V_0 = 0;
	bool V_1 = false;
	uint32_t V_2 = 0;
	ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 V_3;
	memset((&V_3), 0, sizeof(V_3));
	ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 V_4;
	memset((&V_4), 0, sizeof(V_4));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_5;
	memset((&V_5), 0, sizeof(V_5));
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B92_0 = NULL;
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B90_0 = NULL;
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B91_0 = NULL;
	int32_t G_B93_0 = 0;
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B93_1 = NULL;
	{
		V_0 = 0;
		bool L_0;
		L_0 = ((  bool (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 1)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, il2cpp_rgctx_method(method->rgctx_data, 1));
		V_1 = L_0;
		bool L_1 = V_1;
		if (!L_1)
		{
			goto IL_0028;
		}
	}
	{
		FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC L_2;
		L_2 = ((  FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 2)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, il2cpp_rgctx_method(method->rgctx_data, 2));
		__this->___m_Writer = L_2;
		FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC* L_3 = (FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC*)(&__this->___m_Writer);
		CHECKED_LOCAL_INIT(FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC_StaticInit,(FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		int32_t L_4;
		L_4 = FastBufferWriter_get_Position_m87642B5268B41B7D15D4E628DF93A5B5776A4B05_inline(L_3, NULL);
		V_0 = L_4;
		goto IL_0041;
	}

IL_0028:
	{
		FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 L_5;
		L_5 = ((  FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 3)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, il2cpp_rgctx_method(method->rgctx_data, 3));
		__this->___m_Reader = L_5;
		FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99* L_6 = (FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99*)(&__this->___m_Reader);
		int32_t L_7;
		L_7 = FastBufferReader_get_Position_m6B9DC9ECC9F2D943EA0103248E10AB9B95C8F4CF_inline(L_6, NULL);
		V_0 = L_7;
	}

IL_0041:
	{
		bool L_8 = V_1;
		if (!L_8)
		{
			goto IL_00e6;
		}
	}
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_9 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_10 = L_9->___UseUnreliableDeltas;
		if (!L_10)
		{
			goto IL_00b1;
		}
	}
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_11 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_12 = L_11->___IsTeleportingNextFrame;
		if (L_12)
		{
			goto IL_0095;
		}
	}
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_13 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_14 = L_13->___IsSynchronizing;
		if (L_14)
		{
			goto IL_0095;
		}
	}
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_15 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_16 = L_15->___UnreliableFrameSync;
		if (L_16)
		{
			goto IL_0095;
		}
	}
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_17 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_18 = L_17->___UseHalfFloatPrecision;
		if (!L_18)
		{
			goto IL_00a3;
		}
	}
	{
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_19 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		bool L_20 = L_19->___CollapsedDeltaIntoBase;
		if (!L_20)
		{
			goto IL_00a3;
		}
	}

IL_0095:
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_21 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		L_21->___ReliableSequenced = (bool)1;
		goto IL_00bd;
	}

IL_00a3:
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_22 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		L_22->___ReliableSequenced = (bool)0;
		goto IL_00bd;
	}

IL_00b1:
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_23 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		L_23->___ReliableSequenced = (bool)1;
	}

IL_00bd:
	{
		FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC L_24 = __this->___m_Writer;
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_25 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		uint32_t L_26;
		L_26 = FlagStates_GetBitsetRepresentation_m7002081C4C5BD54947BD04940B1FA592C83CEC3B_inline(L_25, NULL);
		BytePacker_WriteValueBitPacked_m50033FEA83560CA7AF9668B3C7352E013D518F11(L_24, L_26, NULL);
		FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC L_27 = __this->___m_Writer;
		int32_t L_28 = __this->___NetworkTick;
		BytePacker_WriteValueBitPacked_m510F6322BA0F2C85AF9527A7927FF9B03F0AE613(L_27, L_28, NULL);
		goto IL_0110;
	}

IL_00e6:
	{
		FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 L_29 = __this->___m_Reader;
		ByteUnpacker_ReadValueBitPacked_mACA5F48002EFB41F31DB0F4AAB4936A2E423DCA4(L_29, (&V_2), NULL);
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_30 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		uint32_t L_31 = V_2;
		FlagStates_SetStateFromBitset_m88B26BC623EA70281C6F7A973DC460786017B638_inline(L_30, L_31, NULL);
		FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 L_32 = __this->___m_Reader;
		int32_t* L_33 = (int32_t*)(&__this->___NetworkTick);
		ByteUnpacker_ReadValueBitPacked_mC5142499F3BA1F4D8C60EDF335D6C54B0D78C4AC(L_32, L_33, NULL);
	}

IL_0110:
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_34 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_35 = L_34->___TrackByStateId;
		if (!L_35)
		{
			goto IL_0133;
		}
	}
	{
		int32_t* L_36 = (int32_t*)(&__this->___StateId);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_37 = V_3;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, int32_t*, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 4)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_36, L_37, il2cpp_rgctx_method(method->rgctx_data, 4));
	}

IL_0133:
	{
		bool L_38;
		L_38 = NetworkTransformState_get_HasPositionChange_mF827577ABA451C60526B23885B255D1285B1FBBF_inline(__this, NULL);
		if (!L_38)
		{
			goto IL_02a2;
		}
	}
	{
		bool L_39;
		L_39 = NetworkTransformState_get_UseHalfFloatPrecision_m0513126B8151A8353AF0931D1E792F9E064C7FA8_inline(__this, NULL);
		if (!L_39)
		{
			goto IL_0248;
		}
	}
	{
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_40 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_41 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_42 = L_41->___SynchronizeBaseHalfFloat;
		L_40->___SynchronizeBase = L_42;
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_43 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_44 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&L_43->___HalfVector3);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_45 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_44->___AxisToSynchronize);
		bool L_46;
		L_46 = NetworkTransformState_get_HasPositionX_mC8E02257F7B924AF10C4E88A21C6DF55264A6451_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_45, 0, L_46, NULL);
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_47 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_48 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&L_47->___HalfVector3);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_49 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_48->___AxisToSynchronize);
		bool L_50;
		L_50 = NetworkTransformState_get_HasPositionY_mB77D3E22968FCB3B1F946A7F963E6AFABF915D89_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_49, 1, L_50, NULL);
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_51 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_52 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&L_51->___HalfVector3);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_53 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_52->___AxisToSynchronize);
		bool L_54;
		L_54 = NetworkTransformState_get_HasPositionZ_m3EB043B0EBA833E145F80474615FA82061165C9B_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_53, 2, L_54, NULL);
		bool L_55;
		L_55 = NetworkTransformState_get_IsTeleportingNextFrame_m7139315A1CE849C8DBB503EA4154E6D71582B254_inline(__this, NULL);
		if (!L_55)
		{
			goto IL_0217;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_56 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___CurrentPosition);
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 5)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_56, il2cpp_rgctx_method(method->rgctx_data, 5));
		bool L_57;
		L_57 = NetworkTransformState_get_IsSynchronizing_m99FE076BE4E9D7AB6F7DAF16523F5B72027269EE_inline(__this, NULL);
		if (!L_57)
		{
			goto IL_02a2;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_58 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___DeltaPosition);
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 5)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_58, il2cpp_rgctx_method(method->rgctx_data, 5));
		bool L_59 = V_1;
		if (L_59)
		{
			goto IL_0205;
		}
	}
	{
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_60 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		int32_t L_61 = __this->___NetworkTick;
		L_60->___NetworkTick = L_61;
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_62 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		il2cpp_codegen_memcpy(L_63, ___0_serializer, SizeOf_BufferSerializer_1_t1869AF78A7B65A1901809CB66D3F187CB0BD7F14);
		InvokerActionInvoker1< BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 6)), il2cpp_rgctx_method(method->rgctx_data, 6), L_62, L_63);
		goto IL_02a2;
	}

IL_0205:
	{
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_64 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 7)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_64, il2cpp_rgctx_method(method->rgctx_data, 7));
		goto IL_02a2;
	}

IL_0217:
	{
		bool L_65 = V_1;
		if (L_65)
		{
			goto IL_0239;
		}
	}
	{
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_66 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		int32_t L_67 = __this->___NetworkTick;
		L_66->___NetworkTick = L_67;
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_68 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		il2cpp_codegen_memcpy(L_69, ___0_serializer, SizeOf_BufferSerializer_1_t1869AF78A7B65A1901809CB66D3F187CB0BD7F14);
		InvokerActionInvoker1< BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 6)), il2cpp_rgctx_method(method->rgctx_data, 6), L_68, L_69);
		goto IL_02a2;
	}

IL_0239:
	{
		NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9* L_70 = (NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*)(&__this->___NetworkDeltaPosition);
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, NetworkDeltaPosition_tD1DE84F6587BF2B08490254D05F79F260D234FE9*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 7)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_70, il2cpp_rgctx_method(method->rgctx_data, 7));
		goto IL_02a2;
	}

IL_0248:
	{
		bool L_71;
		L_71 = NetworkTransformState_get_HasPositionX_mC8E02257F7B924AF10C4E88A21C6DF55264A6451_inline(__this, NULL);
		if (!L_71)
		{
			goto IL_0266;
		}
	}
	{
		float* L_72 = (float*)(&__this->___PositionX);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_73 = V_3;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, float*, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 8)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_72, L_73, il2cpp_rgctx_method(method->rgctx_data, 8));
	}

IL_0266:
	{
		bool L_74;
		L_74 = NetworkTransformState_get_HasPositionY_mB77D3E22968FCB3B1F946A7F963E6AFABF915D89_inline(__this, NULL);
		if (!L_74)
		{
			goto IL_0284;
		}
	}
	{
		float* L_75 = (float*)(&__this->___PositionY);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_76 = V_3;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, float*, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 8)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_75, L_76, il2cpp_rgctx_method(method->rgctx_data, 8));
	}

IL_0284:
	{
		bool L_77;
		L_77 = NetworkTransformState_get_HasPositionZ_m3EB043B0EBA833E145F80474615FA82061165C9B_inline(__this, NULL);
		if (!L_77)
		{
			goto IL_02a2;
		}
	}
	{
		float* L_78 = (float*)(&__this->___PositionZ);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_79 = V_3;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, float*, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 8)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_78, L_79, il2cpp_rgctx_method(method->rgctx_data, 8));
	}

IL_02a2:
	{
		bool L_80;
		L_80 = NetworkTransformState_get_HasRotAngleChange_m4D900826D7636E38F55B6BEDBD88A61230FEE50A_inline(__this, NULL);
		if (!L_80)
		{
			goto IL_04c2;
		}
	}
	{
		bool L_81;
		L_81 = NetworkTransformState_get_QuaternionSync_mBB94E4FD11175FD76DDF0EAEB0210E369F28C747_inline(__this, NULL);
		if (!L_81)
		{
			goto IL_0377;
		}
	}
	{
		bool L_82;
		L_82 = NetworkTransformState_get_IsTeleportingNextFrame_m7139315A1CE849C8DBB503EA4154E6D71582B254_inline(__this, NULL);
		if (!L_82)
		{
			goto IL_02d2;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_83 = (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*)(&__this->___Rotation);
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 9)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_83, il2cpp_rgctx_method(method->rgctx_data, 9));
		goto IL_04c2;
	}

IL_02d2:
	{
		bool L_84;
		L_84 = NetworkTransformState_get_QuaternionCompression_m0473AF4A43B2923E5C2359643E3C7C68DEE6339B_inline(__this, NULL);
		if (!L_84)
		{
			goto IL_0320;
		}
	}
	{
		bool L_85 = V_1;
		if (!L_85)
		{
			goto IL_02ee;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_86 = (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*)(&__this->___Rotation);
		uint32_t L_87;
		L_87 = QuaternionCompressor_CompressQuaternion_mDFB8E04C1429D8183D314DAEA13E7725C0FADDAD_inline(L_86, NULL);
		__this->___QuaternionCompressed = L_87;
	}

IL_02ee:
	{
		uint32_t* L_88 = (uint32_t*)(&__this->___QuaternionCompressed);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_89 = V_3;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, uint32_t*, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 10)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_88, L_89, il2cpp_rgctx_method(method->rgctx_data, 10));
		bool L_90 = V_1;
		if (L_90)
		{
			goto IL_04c2;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_91 = (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*)(&__this->___Rotation);
		uint32_t L_92 = __this->___QuaternionCompressed;
		QuaternionCompressor_DecompressQuaternion_mDABA28208E32355842F5BFA792A08813DBE82F51_inline(L_91, L_92, NULL);
		goto IL_04c2;
	}

IL_0320:
	{
		bool L_93;
		L_93 = NetworkTransformState_get_UseHalfFloatPrecision_m0513126B8151A8353AF0931D1E792F9E064C7FA8_inline(__this, NULL);
		if (!L_93)
		{
			goto IL_0365;
		}
	}
	{
		bool L_94 = V_1;
		if (!L_94)
		{
			goto IL_033c;
		}
	}
	{
		HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD* L_95 = (HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD*)(&__this->___HalfVectorRotation);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_96 = (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*)(&__this->___Rotation);
		HalfVector4_UpdateFrom_m49F84D6FA68D9025729B9AE5BED74C42FC1C2A4D_inline(L_95, L_96, NULL);
	}

IL_033c:
	{
		HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD* L_97 = (HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD*)(&__this->___HalfVectorRotation);
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 11)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_97, il2cpp_rgctx_method(method->rgctx_data, 11));
		bool L_98 = V_1;
		if (L_98)
		{
			goto IL_04c2;
		}
	}
	{
		HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD* L_99 = (HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD*)(&__this->___HalfVectorRotation);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_100;
		L_100 = HalfVector4_ToQuaternion_m2A8121C41C193D8B2BE815FE6C741057B4BD85C5_inline(L_99, NULL);
		__this->___Rotation = L_100;
		goto IL_04c2;
	}

IL_0365:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_101 = (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*)(&__this->___Rotation);
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 9)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_101, il2cpp_rgctx_method(method->rgctx_data, 9));
		goto IL_04c2;
	}

IL_0377:
	{
		bool L_102;
		L_102 = NetworkTransformState_get_UseHalfFloatPrecision_m0513126B8151A8353AF0931D1E792F9E064C7FA8_inline(__this, NULL);
		if (!L_102)
		{
			goto IL_0468;
		}
	}
	{
		bool L_103;
		L_103 = NetworkTransformState_get_IsTeleportingNextFrame_m7139315A1CE849C8DBB503EA4154E6D71582B254_inline(__this, NULL);
		if (L_103)
		{
			goto IL_0468;
		}
	}
	{
		bool L_104;
		L_104 = NetworkTransformState_get_HasRotAngleChange_m4D900826D7636E38F55B6BEDBD88A61230FEE50A_inline(__this, NULL);
		if (!L_104)
		{
			goto IL_04c2;
		}
	}
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_105 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfEulerRotation);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_106 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_105->___AxisToSynchronize);
		bool L_107;
		L_107 = NetworkTransformState_get_HasRotAngleX_m2017FDEB7C6355F80DCAD0258AA5486D6FBDC816_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_106, 0, L_107, NULL);
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_108 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfEulerRotation);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_109 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_108->___AxisToSynchronize);
		bool L_110;
		L_110 = NetworkTransformState_get_HasRotAngleY_m1D53E40810F158FDFEEAC32A1487E63ABC5CB040_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_109, 1, L_110, NULL);
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_111 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfEulerRotation);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_112 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_111->___AxisToSynchronize);
		bool L_113;
		L_113 = NetworkTransformState_get_HasRotAngleZ_m5B23DA8ED870129BF35C9A82B7776605C248DE04_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_112, 2, L_113, NULL);
		bool L_114 = V_1;
		if (!L_114)
		{
			goto IL_03fd;
		}
	}
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_115 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfEulerRotation);
		float L_116 = __this->___RotAngleX;
		float L_117 = __this->___RotAngleY;
		float L_118 = __this->___RotAngleZ;
		HalfVector3_Set_m442C051B289196D68C7B0C6C38ABBA71EADDADEA(L_115, L_116, L_117, L_118, NULL);
	}

IL_03fd:
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_119 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfEulerRotation);
		il2cpp_codegen_initobj((&V_4), sizeof(ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3));
		ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 L_120 = V_4;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*, ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 12)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_119, L_120, il2cpp_rgctx_method(method->rgctx_data, 12));
		bool L_121 = V_1;
		if (L_121)
		{
			goto IL_04c2;
		}
	}
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_122 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfEulerRotation);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_123;
		L_123 = HalfVector3_ToVector3_m0D9B03E9618FA457A3A527E30AA765EB4093D0D1_inline(L_122, NULL);
		V_5 = L_123;
		bool L_124;
		L_124 = NetworkTransformState_get_HasRotAngleX_m2017FDEB7C6355F80DCAD0258AA5486D6FBDC816_inline(__this, NULL);
		if (!L_124)
		{
			goto IL_043c;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_125 = V_5;
		float L_126 = L_125.___x;
		__this->___RotAngleX = L_126;
	}

IL_043c:
	{
		bool L_127;
		L_127 = NetworkTransformState_get_HasRotAngleY_m1D53E40810F158FDFEEAC32A1487E63ABC5CB040_inline(__this, NULL);
		if (!L_127)
		{
			goto IL_0451;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_128 = V_5;
		float L_129 = L_128.___y;
		__this->___RotAngleY = L_129;
	}

IL_0451:
	{
		bool L_130;
		L_130 = NetworkTransformState_get_HasRotAngleZ_m5B23DA8ED870129BF35C9A82B7776605C248DE04_inline(__this, NULL);
		if (!L_130)
		{
			goto IL_04c2;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_131 = V_5;
		float L_132 = L_131.___z;
		__this->___RotAngleZ = L_132;
		goto IL_04c2;
	}

IL_0468:
	{
		bool L_133;
		L_133 = NetworkTransformState_get_HasRotAngleX_m2017FDEB7C6355F80DCAD0258AA5486D6FBDC816_inline(__this, NULL);
		if (!L_133)
		{
			goto IL_0486;
		}
	}
	{
		float* L_134 = (float*)(&__this->___RotAngleX);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_135 = V_3;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, float*, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 8)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_134, L_135, il2cpp_rgctx_method(method->rgctx_data, 8));
	}

IL_0486:
	{
		bool L_136;
		L_136 = NetworkTransformState_get_HasRotAngleY_m1D53E40810F158FDFEEAC32A1487E63ABC5CB040_inline(__this, NULL);
		if (!L_136)
		{
			goto IL_04a4;
		}
	}
	{
		float* L_137 = (float*)(&__this->___RotAngleY);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_138 = V_3;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, float*, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 8)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_137, L_138, il2cpp_rgctx_method(method->rgctx_data, 8));
	}

IL_04a4:
	{
		bool L_139;
		L_139 = NetworkTransformState_get_HasRotAngleZ_m5B23DA8ED870129BF35C9A82B7776605C248DE04_inline(__this, NULL);
		if (!L_139)
		{
			goto IL_04c2;
		}
	}
	{
		float* L_140 = (float*)(&__this->___RotAngleZ);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_141 = V_3;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, float*, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 8)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_140, L_141, il2cpp_rgctx_method(method->rgctx_data, 8));
	}

IL_04c2:
	{
		bool L_142;
		L_142 = NetworkTransformState_get_HasScaleChange_mD5FBA90EF892DC24F087B409A4A4F04178E955F7_inline(__this, NULL);
		if (!L_142)
		{
			goto IL_0660;
		}
	}
	{
		bool L_143;
		L_143 = NetworkTransformState_get_IsTeleportingNextFrame_m7139315A1CE849C8DBB503EA4154E6D71582B254_inline(__this, NULL);
		if (!L_143)
		{
			goto IL_04ef;
		}
	}
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_144 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_145 = L_144->___IsParented;
		if (!L_145)
		{
			goto IL_04ef;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_146 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___LossyScale);
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 5)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_146, il2cpp_rgctx_method(method->rgctx_data, 5));
	}

IL_04ef:
	{
		bool L_147;
		L_147 = NetworkTransformState_get_UseHalfFloatPrecision_m0513126B8151A8353AF0931D1E792F9E064C7FA8_inline(__this, NULL);
		if (!L_147)
		{
			goto IL_0606;
		}
	}
	{
		bool L_148;
		L_148 = NetworkTransformState_get_IsTeleportingNextFrame_m7139315A1CE849C8DBB503EA4154E6D71582B254_inline(__this, NULL);
		if (!L_148)
		{
			goto IL_0514;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_149 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___Scale);
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 5)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_149, il2cpp_rgctx_method(method->rgctx_data, 5));
		goto IL_0660;
	}

IL_0514:
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_150 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfVectorScale);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_151 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_150->___AxisToSynchronize);
		bool L_152;
		L_152 = NetworkTransformState_get_HasScaleX_m82B5E6E8FD2A17E31F8B4179124227E34D190756_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_151, 0, L_152, NULL);
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_153 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfVectorScale);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_154 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_153->___AxisToSynchronize);
		bool L_155;
		L_155 = NetworkTransformState_get_HasScaleY_mC709C18060AFD0D5944B749FAE96A82F8B078821_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_154, 1, L_155, NULL);
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_156 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfVectorScale);
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_157 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&L_156->___AxisToSynchronize);
		bool L_158;
		L_158 = NetworkTransformState_get_HasScaleZ_m812D411158FC2B56DFE0BC3EA77A999220F52FD8_inline(__this, NULL);
		bool3_set_Item_m97B15081414771CC507C55695692865801C588A6(L_157, 2, L_158, NULL);
		bool L_159 = V_1;
		if (!L_159)
		{
			goto IL_058b;
		}
	}
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_160 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfVectorScale);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_161 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___Scale);
		float L_162;
		L_162 = Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_inline(L_161, 0, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_163 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___Scale);
		float L_164;
		L_164 = Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_inline(L_163, 1, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_165 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___Scale);
		float L_166;
		L_166 = Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_inline(L_165, 2, NULL);
		HalfVector3_Set_m442C051B289196D68C7B0C6C38ABBA71EADDADEA(L_160, L_162, L_164, L_166, NULL);
	}

IL_058b:
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_167 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfVectorScale);
		il2cpp_codegen_initobj((&V_4), sizeof(ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3));
		ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3 L_168 = V_4;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*, ForNetworkSerializable_t9761409AA2A84D519B485A78188E85CFF1A9C7E3, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 12)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_167, L_168, il2cpp_rgctx_method(method->rgctx_data, 12));
		bool L_169 = V_1;
		if (L_169)
		{
			goto IL_0660;
		}
	}
	{
		HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* L_170 = (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02*)(&__this->___HalfVectorScale);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_171;
		L_171 = HalfVector3_ToVector3_m0D9B03E9618FA457A3A527E30AA765EB4093D0D1_inline(L_170, NULL);
		__this->___Scale = L_171;
		bool L_172;
		L_172 = NetworkTransformState_get_HasScaleX_m82B5E6E8FD2A17E31F8B4179124227E34D190756_inline(__this, NULL);
		if (!L_172)
		{
			goto IL_05d2;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_173 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___Scale);
		float L_174 = L_173->___x;
		__this->___ScaleX = L_174;
	}

IL_05d2:
	{
		bool L_175;
		L_175 = NetworkTransformState_get_HasScaleY_mC709C18060AFD0D5944B749FAE96A82F8B078821_inline(__this, NULL);
		if (!L_175)
		{
			goto IL_05eb;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_176 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___Scale);
		float L_177 = L_176->___y;
		__this->___ScaleY = L_177;
	}

IL_05eb:
	{
		bool L_178;
		L_178 = NetworkTransformState_get_HasScaleZ_m812D411158FC2B56DFE0BC3EA77A999220F52FD8_inline(__this, NULL);
		if (!L_178)
		{
			goto IL_0660;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_179 = (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)(&__this->___Scale);
		float L_180 = L_179->___x;
		__this->___ScaleZ = L_180;
		goto IL_0660;
	}

IL_0606:
	{
		bool L_181;
		L_181 = NetworkTransformState_get_HasScaleX_m82B5E6E8FD2A17E31F8B4179124227E34D190756_inline(__this, NULL);
		if (!L_181)
		{
			goto IL_0624;
		}
	}
	{
		float* L_182 = (float*)(&__this->___ScaleX);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_183 = V_3;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, float*, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 8)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_182, L_183, il2cpp_rgctx_method(method->rgctx_data, 8));
	}

IL_0624:
	{
		bool L_184;
		L_184 = NetworkTransformState_get_HasScaleY_mC709C18060AFD0D5944B749FAE96A82F8B078821_inline(__this, NULL);
		if (!L_184)
		{
			goto IL_0642;
		}
	}
	{
		float* L_185 = (float*)(&__this->___ScaleY);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_186 = V_3;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, float*, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 8)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_185, L_186, il2cpp_rgctx_method(method->rgctx_data, 8));
	}

IL_0642:
	{
		bool L_187;
		L_187 = NetworkTransformState_get_HasScaleZ_m812D411158FC2B56DFE0BC3EA77A999220F52FD8_inline(__this, NULL);
		if (!L_187)
		{
			goto IL_0660;
		}
	}
	{
		float* L_188 = (float*)(&__this->___ScaleZ);
		il2cpp_codegen_initobj((&V_3), sizeof(ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292));
		ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292 L_189 = V_3;
		((  void (*) (BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*, float*, ForPrimitives_t4120884959A3BC3EAC3D4980A4DA8010E09DA292, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 8)))((BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10*)___0_serializer, L_188, L_189, il2cpp_rgctx_method(method->rgctx_data, 8));
	}

IL_0660:
	{
		bool L_190 = V_1;
		if (L_190)
		{
			goto IL_069b;
		}
	}
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_191 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_192;
		L_192 = NetworkTransformState_get_HasPositionChange_mF827577ABA451C60526B23885B255D1285B1FBBF_inline(__this, NULL);
		if (L_192)
		{
			G_B92_0 = L_191;
			goto IL_0681;
		}
		G_B90_0 = L_191;
	}
	{
		bool L_193;
		L_193 = NetworkTransformState_get_HasRotAngleChange_m4D900826D7636E38F55B6BEDBD88A61230FEE50A_inline(__this, NULL);
		if (L_193)
		{
			G_B92_0 = G_B90_0;
			goto IL_0681;
		}
		G_B91_0 = G_B90_0;
	}
	{
		bool L_194;
		L_194 = NetworkTransformState_get_HasScaleChange_mD5FBA90EF892DC24F087B409A4A4F04178E955F7_inline(__this, NULL);
		G_B93_0 = ((int32_t)(L_194));
		G_B93_1 = G_B91_0;
		goto IL_0682;
	}

IL_0681:
	{
		G_B93_0 = 1;
		G_B93_1 = G_B92_0;
	}

IL_0682:
	{
		G_B93_1->___IsDirty = (bool)G_B93_0;
		FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99* L_195 = (FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99*)(&__this->___m_Reader);
		int32_t L_196;
		L_196 = FastBufferReader_get_Position_m6B9DC9ECC9F2D943EA0103248E10AB9B95C8F4CF_inline(L_195, NULL);
		int32_t L_197 = V_0;
		NetworkTransformState_set_LastSerializedSize_m495ABA7CDD6AC0B7900EF02669F839F002427BF2_inline(__this, ((int32_t)il2cpp_codegen_subtract(L_196, L_197)), NULL);
		return;
	}

IL_069b:
	{
		FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC* L_198 = (FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC*)(&__this->___m_Writer);
		CHECKED_LOCAL_INIT(FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC_StaticInit,(FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		int32_t L_199;
		L_199 = FastBufferWriter_get_Position_m87642B5268B41B7D15D4E628DF93A5B5776A4B05_inline(L_198, NULL);
		int32_t L_200 = V_0;
		NetworkTransformState_set_LastSerializedSize_m495ABA7CDD6AC0B7900EF02669F839F002427BF2_inline(__this, ((int32_t)il2cpp_codegen_subtract(L_199, L_200)), NULL);
		return;
	}
}
IL2CPP_EXTERN_C  void NetworkTransformState_NetworkSerialize_TisIl2CppFullySharedGenericAny_mCF668FDFEBE2180BB40C932053267AF2F816687C_AdjustorThunk (RuntimeObject* __this, BufferSerializer_1_tC485B3539F0BCD2241145A679FB202806C206C10 ___0_serializer, const RuntimeMethod* method)
{
	NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* _thisAdjusted;
	_thisAdjusted = il2cpp_codegen_get_raw_data<NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED>(__this);
	NetworkTransformState_NetworkSerialize_TisIl2CppFullySharedGenericAny_mCF668FDFEBE2180BB40C932053267AF2F816687C(_thisAdjusted, ___0_serializer, method);
}
// Method Definition Index: 44196
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR intptr_t MarshalledUnityObject_Marshal_TisIl2CppSharedGenericObject_m35CB06885EF5600EDBB840B54EDAF3A806896DBB_gshared (Il2CppSharedGenericObject* ___0_obj, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		Il2CppSharedGenericObject* L_0 = ___0_obj;
		if (L_0)
		{
			goto IL_000e;
		}
	}
	{
		return 0;
	}

IL_000e:
	{
		Il2CppSharedGenericObject* L_1 = ___0_obj;
		intptr_t L_2;
		L_2 = MarshalledUnityObject_MarshalNotNull_TisIl2CppSharedGenericObject_mCE897EC9A79983B4B1E6E2C8342452256309044A_inline(L_1, NULL);
		return L_2;
	}
}
// Method Definition Index: 44197
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR intptr_t MarshalledUnityObject_MarshalNotNull_TisIl2CppSharedGenericObject_mCE897EC9A79983B4B1E6E2C8342452256309044A_gshared (Il2CppSharedGenericObject* ___0_obj, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		Il2CppSharedGenericObject* L_0 = ___0_obj;
		NullCheck(L_0);
		intptr_t L_1 = ((Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)L_0)->___m_CachedPtr;
		return L_1;
	}
}
// Method Definition Index: 44199
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Il2CppSharedGenericObject* MarshalledUnityObject_Unmarshal_TisIl2CppSharedGenericObject_mDFF812844C3A315BA334E9FD102E4EE28E2847B1_gshared (intptr_t ___0_gcHandlePtr, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	//<source_info:<no-source>:1>
	GCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC V_0;
	memset((&V_0), 0, sizeof(V_0));
	Il2CppSharedGenericObject* V_1 = NULL;
	{
		intptr_t L_0 = ___0_gcHandlePtr;
		bool L_1;
		L_1 = IntPtr_op_Equality_m7D9CDCDE9DC2A0C2C614633F4921E90187FAB271_inline(L_0, 0, NULL);
		if (!L_1)
		{
			goto IL_0017;
		}
	}
	{
		il2cpp_codegen_initobj((&V_1), sizeof(Il2CppSharedGenericObject*));
		Il2CppSharedGenericObject* L_2 = V_1;
		return L_2;
	}

IL_0017:
	{
		intptr_t L_3 = ___0_gcHandlePtr;
		GCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC L_4;
		L_4 = MarshalledUnityObject_FromIntPtrUnsafe_m1C5AE0FB7CD1978A8387B0081DB909BAAC2324C3_inline(L_3, NULL);
		V_0 = L_4;
		RuntimeObject* L_5;
		L_5 = GCHandle_get_Target_m481F9508DA5E384D33CD1F4450060DC56BBD4CD5_inline((&V_0), NULL);
		return ((Il2CppSharedGenericObject*)Castclass((RuntimeObject*)L_5, il2cpp_rgctx_data(method->rgctx_data, 0)));
	}
}
// Method Definition Index: 92869
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void GetPropertyVisitor_VisitPath_TisIl2CppFullySharedGenericAny_TisIl2CppFullySharedGenericAny_m48D5F231D141FE04D8C4AA045C484BDF9928EBC0_fshared (GetPropertyVisitor_t88183F280884F26458B42DAF173F005F3625F540* __this, Property_2_tE9B27417C17E0D8EA0D6A88F71B3C9347F2332A3* ___0_property, Il2CppFullySharedGenericAny* ___1_container, Il2CppFullySharedGenericAny* ___2_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		Property_2_tE9B27417C17E0D8EA0D6A88F71B3C9347F2332A3* L_0 = ___0_property;
		__this->___Property = (RuntimeObject*)L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___Property), (void*)(RuntimeObject*)L_0);
		return;
	}
}
// Method Definition Index: 78752
// Method Definition Index: 78752
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785* ExpressionQuoter_VisitLambda_TisIl2CppFullySharedGenericAny_m0060183C8192066670005792D19D2EC19C50DBB7_fshared (ExpressionQuoter_t3D5F35B2980800F7F947EBC0819D867CF5AAD536* __this, Expression_1_t0FC093B0DDEA1EB4F5EF3152CC33F1B785E80EA4* ___0_node, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&HashSet_1_Add_m9B1803FBD20D89F056AD75F1B6B0E1F5D5CF4F69_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&HashSet_1__ctor_mC6742D4B2D1A12A042DB56C25EEF951C4BAC992B_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&HashSet_1_t068F5201D923072F46716204841D21328FE6218D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Stack_1_Pop_mBE2B08F95D18382A9C64D99E1065B899EB75E6E5_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Stack_1_Push_m7705C6FDAFECD165E7E24091F066CB47F323E6CE_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	//<source_info:<no-source>:1>
	Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785* V_0 = NULL;
	HashSet_1_t068F5201D923072F46716204841D21328FE6218D* V_1 = NULL;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	{
		Expression_1_t0FC093B0DDEA1EB4F5EF3152CC33F1B785E80EA4* L_0 = ___0_node;
		NullCheck((LambdaExpression_tD26FB6AEAD01B2EBB668CDEAFAAFA4948697300E*)L_0);
		int32_t L_1;
		L_1 = VirtualFuncInvoker0< int32_t >::Invoke(17, (LambdaExpression_tD26FB6AEAD01B2EBB668CDEAFAAFA4948697300E*)L_0);
		if ((((int32_t)L_1) <= ((int32_t)0)))
		{
			goto IL_003c;
		}
	}
	{
		HashSet_1_t068F5201D923072F46716204841D21328FE6218D* L_2 = (HashSet_1_t068F5201D923072F46716204841D21328FE6218D*)il2cpp_codegen_object_new(HashSet_1_t068F5201D923072F46716204841D21328FE6218D_il2cpp_TypeInfo_var);
		HashSet_1__ctor_mC6742D4B2D1A12A042DB56C25EEF951C4BAC992B(L_2, HashSet_1__ctor_mC6742D4B2D1A12A042DB56C25EEF951C4BAC992B_RuntimeMethod_var);
		V_1 = L_2;
		V_2 = 0;
		Expression_1_t0FC093B0DDEA1EB4F5EF3152CC33F1B785E80EA4* L_3 = ___0_node;
		NullCheck((LambdaExpression_tD26FB6AEAD01B2EBB668CDEAFAAFA4948697300E*)L_3);
		int32_t L_4;
		L_4 = VirtualFuncInvoker0< int32_t >::Invoke(17, (LambdaExpression_tD26FB6AEAD01B2EBB668CDEAFAAFA4948697300E*)L_3);
		V_3 = L_4;
		goto IL_002c;
	}

IL_001a:
	{
		HashSet_1_t068F5201D923072F46716204841D21328FE6218D* L_5 = V_1;
		Expression_1_t0FC093B0DDEA1EB4F5EF3152CC33F1B785E80EA4* L_6 = ___0_node;
		int32_t L_7 = V_2;
		NullCheck((LambdaExpression_tD26FB6AEAD01B2EBB668CDEAFAAFA4948697300E*)L_6);
		ParameterExpression_tE8D3A1137422F75D256CBB200EDC82820F240110* L_8;
		L_8 = VirtualFuncInvoker1< ParameterExpression_tE8D3A1137422F75D256CBB200EDC82820F240110*, int32_t >::Invoke(16, (LambdaExpression_tD26FB6AEAD01B2EBB668CDEAFAAFA4948697300E*)L_6, L_7);
		NullCheck(L_5);
		bool L_9;
		L_9 = HashSet_1_Add_m9B1803FBD20D89F056AD75F1B6B0E1F5D5CF4F69(L_5, L_8, HashSet_1_Add_m9B1803FBD20D89F056AD75F1B6B0E1F5D5CF4F69_RuntimeMethod_var);
		int32_t L_10 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_10, 1));
	}

IL_002c:
	{
		int32_t L_11 = V_2;
		int32_t L_12 = V_3;
		if ((((int32_t)L_11) < ((int32_t)L_12)))
		{
			goto IL_001a;
		}
	}
	{
		Stack_1_tC4810ACEE7FD00840B5CB4333A83E2E1553CAD26* L_13 = __this->____shadowedVars;
		HashSet_1_t068F5201D923072F46716204841D21328FE6218D* L_14 = V_1;
		NullCheck(L_13);
		Stack_1_Push_m7705C6FDAFECD165E7E24091F066CB47F323E6CE(L_13, L_14, Stack_1_Push_m7705C6FDAFECD165E7E24091F066CB47F323E6CE_RuntimeMethod_var);
	}

IL_003c:
	{
		Expression_1_t0FC093B0DDEA1EB4F5EF3152CC33F1B785E80EA4* L_15 = ___0_node;
		NullCheck((LambdaExpression_tD26FB6AEAD01B2EBB668CDEAFAAFA4948697300E*)L_15);
		Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785* L_16;
		L_16 = LambdaExpression_get_Body_m161E156442547AE8A6837C5AE065BD93345451DE_inline((LambdaExpression_tD26FB6AEAD01B2EBB668CDEAFAAFA4948697300E*)L_15, NULL);
		Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785* L_17;
		L_17 = VirtualFuncInvoker1< Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785*, Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785* >::Invoke(4, __this, L_16);
		V_0 = L_17;
		Expression_1_t0FC093B0DDEA1EB4F5EF3152CC33F1B785E80EA4* L_18 = ___0_node;
		NullCheck((LambdaExpression_tD26FB6AEAD01B2EBB668CDEAFAAFA4948697300E*)L_18);
		int32_t L_19;
		L_19 = VirtualFuncInvoker0< int32_t >::Invoke(17, (LambdaExpression_tD26FB6AEAD01B2EBB668CDEAFAAFA4948697300E*)L_18);
		if ((((int32_t)L_19) <= ((int32_t)0)))
		{
			goto IL_005e;
		}
	}
	{
		Stack_1_tC4810ACEE7FD00840B5CB4333A83E2E1553CAD26* L_20 = __this->____shadowedVars;
		NullCheck(L_20);
		HashSet_1_t068F5201D923072F46716204841D21328FE6218D* L_21;
		L_21 = Stack_1_Pop_mBE2B08F95D18382A9C64D99E1065B899EB75E6E5(L_20, Stack_1_Pop_mBE2B08F95D18382A9C64D99E1065B899EB75E6E5_RuntimeMethod_var);
	}

IL_005e:
	{
		Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785* L_22 = V_0;
		Expression_1_t0FC093B0DDEA1EB4F5EF3152CC33F1B785E80EA4* L_23 = ___0_node;
		NullCheck((LambdaExpression_tD26FB6AEAD01B2EBB668CDEAFAAFA4948697300E*)L_23);
		Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785* L_24;
		L_24 = LambdaExpression_get_Body_m161E156442547AE8A6837C5AE065BD93345451DE_inline((LambdaExpression_tD26FB6AEAD01B2EBB668CDEAFAAFA4948697300E*)L_23, NULL);
		if ((!(((RuntimeObject*)(Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785*)L_22) == ((RuntimeObject*)(Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785*)L_24))))
		{
			goto IL_0069;
		}
	}
	{
		Expression_1_t0FC093B0DDEA1EB4F5EF3152CC33F1B785E80EA4* L_25 = ___0_node;
		return (Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785*)L_25;
	}

IL_0069:
	{
		Expression_1_t0FC093B0DDEA1EB4F5EF3152CC33F1B785E80EA4* L_26 = ___0_node;
		Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785* L_27 = V_0;
		NullCheck(L_26);
		Expression_1_t0FC093B0DDEA1EB4F5EF3152CC33F1B785E80EA4* L_28;
		L_28 = VirtualFuncInvoker2< Expression_1_t0FC093B0DDEA1EB4F5EF3152CC33F1B785E80EA4*, Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785*, ParameterExpressionU5BU5D_tA217A6969CA4383EF6D3C43B8EB0989358ABE72C* >::Invoke(18, L_26, L_27, (ParameterExpressionU5BU5D_tA217A6969CA4383EF6D3C43B8EB0989358ABE72C*)NULL);
		return (Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785*)L_28;
	}
}
// Method Definition Index: 33820
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t RenderGraphResourcesData_AddNewRenderGraphResource_TisIl2CppSharedGenericObject_mBB87A5C94B2E32833D752DA290821E94102810F7_gshared (RenderGraphResourcesData_t4E1A864AD7A36EC74B28D89C86E3A4D0997958CF* __this, Il2CppSharedGenericObject** ___0_outRes, bool ___1_pooledResource, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DynamicArray_1_Resize_m71330886D4896ECE91617DB09FAF262B0E24B00B_RuntimeMethod_var);
		il2cpp_rgctx_method_init(method);
	}
	//<source_info:<no-source>:1>
	int32_t V_0 = 0;
	RuntimeObject* G_B4_0 = NULL;
	RuntimeObject* G_B3_0 = NULL;
	IRenderGraphResourcePool_tBCC3743B6D9FE5AA6513FE6F643B1A51B7060D35* G_B5_0 = NULL;
	RuntimeObject* G_B5_1 = NULL;
	{
		DynamicArray_1_tE5A650707ED617C8B11E4B6F29F3207E02383467* L_0 = __this->___resourceArray;
		NullCheck(L_0);
		int32_t L_1;
		L_1 = DynamicArray_1_get_size_m0C78CDCD1FF6A1256C3382649AF82DE707BB6C16_inline(L_0, NULL);
		V_0 = L_1;
		DynamicArray_1_tE5A650707ED617C8B11E4B6F29F3207E02383467* L_2 = __this->___resourceArray;
		DynamicArray_1_tE5A650707ED617C8B11E4B6F29F3207E02383467* L_3 = __this->___resourceArray;
		NullCheck(L_3);
		int32_t L_4;
		L_4 = DynamicArray_1_get_size_m0C78CDCD1FF6A1256C3382649AF82DE707BB6C16_inline(L_3, NULL);
		NullCheck(L_2);
		DynamicArray_1_Resize_m71330886D4896ECE91617DB09FAF262B0E24B00B(L_2, ((int32_t)il2cpp_codegen_add(L_4, 1)), (bool)1, DynamicArray_1_Resize_m71330886D4896ECE91617DB09FAF262B0E24B00B_RuntimeMethod_var);
		DynamicArray_1_tE5A650707ED617C8B11E4B6F29F3207E02383467* L_5 = __this->___resourceArray;
		int32_t L_6 = V_0;
		NullCheck(L_5);
		IRenderGraphResource_t8C49F0158EDB9571FA4BDAF754E09A32E535C021** L_7;
		L_7 = DynamicArray_1_get_Item_mEFCD58DBBE282DE955FAEF10ECACCF41D9E04869(L_5, L_6, NULL);
		IRenderGraphResource_t8C49F0158EDB9571FA4BDAF754E09A32E535C021* L_8 = *(L_7);
		if (L_8)
		{
			goto IL_004b;
		}
	}
	{
		DynamicArray_1_tE5A650707ED617C8B11E4B6F29F3207E02383467* L_9 = __this->___resourceArray;
		int32_t L_10 = V_0;
		NullCheck(L_9);
		IRenderGraphResource_t8C49F0158EDB9571FA4BDAF754E09A32E535C021** L_11;
		L_11 = DynamicArray_1_get_Item_mEFCD58DBBE282DE955FAEF10ECACCF41D9E04869(L_9, L_10, NULL);
		Il2CppSharedGenericObject* L_12;
		L_12 = Activator_CreateInstance_TisIl2CppSharedGenericObject_m4C74D3D65600820EB977E87AD08D24AF782C97C3(il2cpp_rgctx_method(method->rgctx_data, 0));
		*(((RuntimeObject**)L_11)) = ((RuntimeObject*)L_12);
		Il2CppCodeGenWriteBarrier((void**)((RuntimeObject**)L_11), (void*)((RuntimeObject*)L_12));
	}

IL_004b:
	{
		Il2CppSharedGenericObject** L_13 = ___0_outRes;
		DynamicArray_1_tE5A650707ED617C8B11E4B6F29F3207E02383467* L_14 = __this->___resourceArray;
		int32_t L_15 = V_0;
		NullCheck(L_14);
		IRenderGraphResource_t8C49F0158EDB9571FA4BDAF754E09A32E535C021** L_16;
		L_16 = DynamicArray_1_get_Item_mEFCD58DBBE282DE955FAEF10ECACCF41D9E04869(L_14, L_15, NULL);
		IRenderGraphResource_t8C49F0158EDB9571FA4BDAF754E09A32E535C021* L_17 = *(L_16);
		*(Il2CppSharedGenericObject**)L_13 = ((Il2CppSharedGenericObject*)IsInst((RuntimeObject*)L_17, il2cpp_rgctx_data(method->rgctx_data, 1)));
		Il2CppCodeGenWriteBarrier((void**)(Il2CppSharedGenericObject**)L_13, (void*)((Il2CppSharedGenericObject*)IsInst((RuntimeObject*)L_17, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppSharedGenericObject** L_18 = ___0_outRes;
		Il2CppSharedGenericObject* L_19 = (*(Il2CppSharedGenericObject**)L_18);
		bool L_20 = ___1_pooledResource;
		if (L_20)
		{
			G_B4_0 = ((RuntimeObject*)(L_19));
			goto IL_0079;
		}
		G_B3_0 = ((RuntimeObject*)(L_19));
	}
	{
		G_B5_0 = ((IRenderGraphResourcePool_tBCC3743B6D9FE5AA6513FE6F643B1A51B7060D35*)(NULL));
		G_B5_1 = G_B3_0;
		goto IL_007f;
	}

IL_0079:
	{
		IRenderGraphResourcePool_tBCC3743B6D9FE5AA6513FE6F643B1A51B7060D35* L_21 = __this->___pool;
		G_B5_0 = L_21;
		G_B5_1 = G_B4_0;
	}

IL_007f:
	{
		NullCheck((IRenderGraphResource_t8C49F0158EDB9571FA4BDAF754E09A32E535C021*)G_B5_1);
		VirtualActionInvoker1< IRenderGraphResourcePool_tBCC3743B6D9FE5AA6513FE6F643B1A51B7060D35* >::Invoke(4, (IRenderGraphResource_t8C49F0158EDB9571FA4BDAF754E09A32E535C021*)G_B5_1, G_B5_0);
		int32_t L_22 = V_0;
		return L_22;
	}
}
// Method Definition Index: 94399
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NativeArray_1_tDB8B8DC66CC8E16ED6D9A8C75D2C1AFC80AC1E18 PhysicsBuffer_ToNativeArray_TisIl2CppFullySharedGenericStruct_m0F9AFB55DC2B342DB7011F2046193F6C30B035C1_fshared (PhysicsBuffer_tCAD034F191834ECD0CAE25B468D0610D84B68A4D* __this, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	//<source_info:<no-source>:1>
	NativeArray_1_tDB8B8DC66CC8E16ED6D9A8C75D2C1AFC80AC1E18 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		int32_t L_0 = __this->___m_Size;
		if (L_0)
		{
			goto IL_0012;
		}
	}
	{
		il2cpp_codegen_initobj((&V_0), sizeof(NativeArray_1_tDB8B8DC66CC8E16ED6D9A8C75D2C1AFC80AC1E18));
		NativeArray_1_tDB8B8DC66CC8E16ED6D9A8C75D2C1AFC80AC1E18 L_1 = V_0;
		return L_1;
	}

IL_0012:
	{
		intptr_t* L_2 = (intptr_t*)(&__this->___m_Buffer);
		void* L_3;
		L_3 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline(L_2, NULL);
		int32_t L_4 = __this->___m_Size;
		int32_t L_5 = __this->___m_Allocator;
		NativeArray_1_tDB8B8DC66CC8E16ED6D9A8C75D2C1AFC80AC1E18 L_6;
		L_6 = ((  NativeArray_1_tDB8B8DC66CC8E16ED6D9A8C75D2C1AFC80AC1E18 (*) (void*, int32_t, int32_t, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 0)))(L_3, L_4, L_5, NULL);
		return L_6;
	}
}
// Method Definition Index: 94399
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NativeArray_1_t7D2E0867BA2C51E53A2DA86335020B175E7CDC86 PhysicsBuffer_ToNativeArray_TisTransformWriteTween_t86FB859350EF146AC5D9CB4CA8196377B714E2B7_m0F0ABCE955A32EF09A1B87865A417AEB795563F6 (PhysicsBuffer_tCAD034F191834ECD0CAE25B468D0610D84B68A4D* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	NativeArray_1_t7D2E0867BA2C51E53A2DA86335020B175E7CDC86 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		int32_t L_0 = __this->___m_Size;
		if (L_0)
		{
			goto IL_0012;
		}
	}
	{
		il2cpp_codegen_initobj((&V_0), sizeof(NativeArray_1_t7D2E0867BA2C51E53A2DA86335020B175E7CDC86));
		NativeArray_1_t7D2E0867BA2C51E53A2DA86335020B175E7CDC86 L_1 = V_0;
		return L_1;
	}

IL_0012:
	{
		intptr_t* L_2 = (intptr_t*)(&__this->___m_Buffer);
		void* L_3;
		L_3 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline(L_2, NULL);
		int32_t L_4 = __this->___m_Size;
		int32_t L_5 = __this->___m_Allocator;
		NativeArray_1_t7D2E0867BA2C51E53A2DA86335020B175E7CDC86 L_6;
		L_6 = NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisTransformWriteTween_t86FB859350EF146AC5D9CB4CA8196377B714E2B7_mCAB0D1991E3CA4A5F2B29699805088ED767C85BF(L_3, L_4, L_5, NULL);
		return L_6;
	}
}
// Method Definition Index: 94399
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NativeArray_1_tD433A29296E2B6926BA29A86B35FEEA6C63C8C68 PhysicsBuffer_ToNativeArray_TisTransformChangeEvent_tAE5E62820ECA07C3DA656E95A0426D046DBF1A70_mED810731A42A4D8DA091409BE1118284E1BDCE90 (PhysicsBuffer_tCAD034F191834ECD0CAE25B468D0610D84B68A4D* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	NativeArray_1_tD433A29296E2B6926BA29A86B35FEEA6C63C8C68 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		int32_t L_0 = __this->___m_Size;
		if (L_0)
		{
			goto IL_0012;
		}
	}
	{
		il2cpp_codegen_initobj((&V_0), sizeof(NativeArray_1_tD433A29296E2B6926BA29A86B35FEEA6C63C8C68));
		NativeArray_1_tD433A29296E2B6926BA29A86B35FEEA6C63C8C68 L_1 = V_0;
		return L_1;
	}

IL_0012:
	{
		intptr_t* L_2 = (intptr_t*)(&__this->___m_Buffer);
		void* L_3;
		L_3 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline(L_2, NULL);
		int32_t L_4 = __this->___m_Size;
		int32_t L_5 = __this->___m_Allocator;
		NativeArray_1_tD433A29296E2B6926BA29A86B35FEEA6C63C8C68 L_6;
		L_6 = NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisTransformChangeEvent_tAE5E62820ECA07C3DA656E95A0426D046DBF1A70_m9FF20AB277A63B6352D86FBE981963C274C1F6CA(L_3, L_4, L_5, NULL);
		return L_6;
	}
}
// Method Definition Index: 94399
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NativeArray_1_tAE73165FE666BFCBFB4CA0B72FFA351ED1872602 PhysicsBuffer_ToNativeArray_TisCapsuleGeometryElement_t834B66F28B944AA313AB50C9C1343105C15B591E_m761C52C5AA4ADD227519287E54411DB038E5F202 (PhysicsBuffer_tCAD034F191834ECD0CAE25B468D0610D84B68A4D* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	NativeArray_1_tAE73165FE666BFCBFB4CA0B72FFA351ED1872602 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		int32_t L_0 = __this->___m_Size;
		if (L_0)
		{
			goto IL_0012;
		}
	}
	{
		il2cpp_codegen_initobj((&V_0), sizeof(NativeArray_1_tAE73165FE666BFCBFB4CA0B72FFA351ED1872602));
		NativeArray_1_tAE73165FE666BFCBFB4CA0B72FFA351ED1872602 L_1 = V_0;
		return L_1;
	}

IL_0012:
	{
		intptr_t* L_2 = (intptr_t*)(&__this->___m_Buffer);
		void* L_3;
		L_3 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline(L_2, NULL);
		int32_t L_4 = __this->___m_Size;
		int32_t L_5 = __this->___m_Allocator;
		NativeArray_1_tAE73165FE666BFCBFB4CA0B72FFA351ED1872602 L_6;
		L_6 = NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisCapsuleGeometryElement_t834B66F28B944AA313AB50C9C1343105C15B591E_m9060EF20AD31BDDBF8E6A4D61F091D03B101F9E4(L_3, L_4, L_5, NULL);
		return L_6;
	}
}
// Method Definition Index: 94399
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NativeArray_1_tBA0BC79DB482632B1DB9D7FF91357CE99B4C73CF PhysicsBuffer_ToNativeArray_TisCircleGeometryElement_t9BD9AA0533C99AD620F9AED6458DFAE45B09B2B1_m37B90A7486634E138E17A378C29EE9B9D5F8D885 (PhysicsBuffer_tCAD034F191834ECD0CAE25B468D0610D84B68A4D* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	NativeArray_1_tBA0BC79DB482632B1DB9D7FF91357CE99B4C73CF V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		int32_t L_0 = __this->___m_Size;
		if (L_0)
		{
			goto IL_0012;
		}
	}
	{
		il2cpp_codegen_initobj((&V_0), sizeof(NativeArray_1_tBA0BC79DB482632B1DB9D7FF91357CE99B4C73CF));
		NativeArray_1_tBA0BC79DB482632B1DB9D7FF91357CE99B4C73CF L_1 = V_0;
		return L_1;
	}

IL_0012:
	{
		intptr_t* L_2 = (intptr_t*)(&__this->___m_Buffer);
		void* L_3;
		L_3 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline(L_2, NULL);
		int32_t L_4 = __this->___m_Size;
		int32_t L_5 = __this->___m_Allocator;
		NativeArray_1_tBA0BC79DB482632B1DB9D7FF91357CE99B4C73CF L_6;
		L_6 = NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisCircleGeometryElement_t9BD9AA0533C99AD620F9AED6458DFAE45B09B2B1_mEFA16883E3A65609AE169271BE4C8883BFC02D22(L_3, L_4, L_5, NULL);
		return L_6;
	}
}
// Method Definition Index: 94399
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NativeArray_1_t2EDCD6FB85206C53A92873BFCBE46ACD9462C683 PhysicsBuffer_ToNativeArray_TisLineElement_t012671A3568902C51830B75D1F5DB18B390F8454_mF73C3A8A23424B2EDD8403FA8F98BB08FD0008F3 (PhysicsBuffer_tCAD034F191834ECD0CAE25B468D0610D84B68A4D* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	NativeArray_1_t2EDCD6FB85206C53A92873BFCBE46ACD9462C683 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		int32_t L_0 = __this->___m_Size;
		if (L_0)
		{
			goto IL_0012;
		}
	}
	{
		il2cpp_codegen_initobj((&V_0), sizeof(NativeArray_1_t2EDCD6FB85206C53A92873BFCBE46ACD9462C683));
		NativeArray_1_t2EDCD6FB85206C53A92873BFCBE46ACD9462C683 L_1 = V_0;
		return L_1;
	}

IL_0012:
	{
		intptr_t* L_2 = (intptr_t*)(&__this->___m_Buffer);
		void* L_3;
		L_3 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline(L_2, NULL);
		int32_t L_4 = __this->___m_Size;
		int32_t L_5 = __this->___m_Allocator;
		NativeArray_1_t2EDCD6FB85206C53A92873BFCBE46ACD9462C683 L_6;
		L_6 = NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisLineElement_t012671A3568902C51830B75D1F5DB18B390F8454_m4A66A3B213055D7307CFE8FEFA301961ABB4D1C8(L_3, L_4, L_5, NULL);
		return L_6;
	}
}
// Method Definition Index: 94399
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NativeArray_1_tE9E9E78E659CC7A96EFD37D8824AEE58DE412CA8 PhysicsBuffer_ToNativeArray_TisPointElement_t5B29DB72B622AE3FF0CFB790DF18EC71970C66A0_m879C0DE9D9F6C9C5F2FF350635AC52F4FF874788 (PhysicsBuffer_tCAD034F191834ECD0CAE25B468D0610D84B68A4D* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	NativeArray_1_tE9E9E78E659CC7A96EFD37D8824AEE58DE412CA8 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		int32_t L_0 = __this->___m_Size;
		if (L_0)
		{
			goto IL_0012;
		}
	}
	{
		il2cpp_codegen_initobj((&V_0), sizeof(NativeArray_1_tE9E9E78E659CC7A96EFD37D8824AEE58DE412CA8));
		NativeArray_1_tE9E9E78E659CC7A96EFD37D8824AEE58DE412CA8 L_1 = V_0;
		return L_1;
	}

IL_0012:
	{
		intptr_t* L_2 = (intptr_t*)(&__this->___m_Buffer);
		void* L_3;
		L_3 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline(L_2, NULL);
		int32_t L_4 = __this->___m_Size;
		int32_t L_5 = __this->___m_Allocator;
		NativeArray_1_tE9E9E78E659CC7A96EFD37D8824AEE58DE412CA8 L_6;
		L_6 = NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisPointElement_t5B29DB72B622AE3FF0CFB790DF18EC71970C66A0_m5F6104B7BABDD0AAEFC152E74ED645A50510E900(L_3, L_4, L_5, NULL);
		return L_6;
	}
}
// Method Definition Index: 94399
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NativeArray_1_tA05A93824C515FF087043027C088AD9C5375BB1D PhysicsBuffer_ToNativeArray_TisPolygonGeometryElement_t4D6D06844AC5A1A51A7DD2F3BBA661FF1C906A57_m8867F6CFE50831DD591716883D3B619545933E0E (PhysicsBuffer_tCAD034F191834ECD0CAE25B468D0610D84B68A4D* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	NativeArray_1_tA05A93824C515FF087043027C088AD9C5375BB1D V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		int32_t L_0 = __this->___m_Size;
		if (L_0)
		{
			goto IL_0012;
		}
	}
	{
		il2cpp_codegen_initobj((&V_0), sizeof(NativeArray_1_tA05A93824C515FF087043027C088AD9C5375BB1D));
		NativeArray_1_tA05A93824C515FF087043027C088AD9C5375BB1D L_1 = V_0;
		return L_1;
	}

IL_0012:
	{
		intptr_t* L_2 = (intptr_t*)(&__this->___m_Buffer);
		void* L_3;
		L_3 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline(L_2, NULL);
		int32_t L_4 = __this->___m_Size;
		int32_t L_5 = __this->___m_Allocator;
		NativeArray_1_tA05A93824C515FF087043027C088AD9C5375BB1D L_6;
		L_6 = NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisPolygonGeometryElement_t4D6D06844AC5A1A51A7DD2F3BBA661FF1C906A57_mBFD05CEEFBE002B3A028DCB2B994626108D1DE63(L_3, L_4, L_5, NULL);
		return L_6;
	}
}
// Method Definition Index: 94401
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ReadOnlySpan_1_tE8C37D9A05FCAB953169AFFE8A0ABCA809781E25 PhysicsBuffer_ToReadOnlySpan_TisIl2CppFullySharedGenericStruct_m7DC92A2EBDE62FBDF265E6AE37A3FAD4CB595ECF_fshared (PhysicsBuffer_tCAD034F191834ECD0CAE25B468D0610D84B68A4D* __this, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	//<source_info:<no-source>:1>
	{
		intptr_t* L_0 = (intptr_t*)(&__this->___m_Buffer);
		void* L_1;
		L_1 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline(L_0, NULL);
		int32_t L_2 = __this->___m_Size;
		ReadOnlySpan_1_tE8C37D9A05FCAB953169AFFE8A0ABCA809781E25 L_3;
		memset((&L_3), 0, sizeof(L_3));
		ReadOnlySpan_1__ctor_m7456175BCB588AEE6932DC60D543FFA702ED3AB8_inline((&L_3), L_1, L_2, il2cpp_rgctx_method(method->rgctx_data, 0));
		return L_3;
	}
}
// Method Definition Index: 94401
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ReadOnlySpan_1_t7C8438B00110311A3FFF078F848928218D9D79F1 PhysicsBuffer_ToReadOnlySpan_TisBodyUpdateTarget_t6013C0FBA9A3E7A8E68F98F01A1B3EA92F574D84_m770A3C01394D2ADEF3AE05D2F391E494DFA44810 (PhysicsBuffer_tCAD034F191834ECD0CAE25B468D0610D84B68A4D* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		intptr_t* L_0 = (intptr_t*)(&__this->___m_Buffer);
		void* L_1;
		L_1 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline(L_0, NULL);
		int32_t L_2 = __this->___m_Size;
		ReadOnlySpan_1_t7C8438B00110311A3FFF078F848928218D9D79F1 L_3;
		memset((&L_3), 0, sizeof(L_3));
		ReadOnlySpan_1__ctor_mD692C6AD4A813B80EF4C2C650DA20A01BAB8B900_inline((&L_3), L_1, L_2, NULL);
		return L_3;
	}
}
// Method Definition Index: 94401
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ReadOnlySpan_1_tD1C684B7FBBE6B196C3D9C25D26C14087DDACC42 PhysicsBuffer_ToReadOnlySpan_TisContactBeginTarget_t56AE151974F2573AEE7A94C0033B3D0F654D58CC_m66F49B0125C73F4C2E594465C8514787C9A2CB23 (PhysicsBuffer_tCAD034F191834ECD0CAE25B468D0610D84B68A4D* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		intptr_t* L_0 = (intptr_t*)(&__this->___m_Buffer);
		void* L_1;
		L_1 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline(L_0, NULL);
		int32_t L_2 = __this->___m_Size;
		ReadOnlySpan_1_tD1C684B7FBBE6B196C3D9C25D26C14087DDACC42 L_3;
		memset((&L_3), 0, sizeof(L_3));
		ReadOnlySpan_1__ctor_m84B3CCED99878FDE74473A0EE7D051C8467D541A_inline((&L_3), L_1, L_2, NULL);
		return L_3;
	}
}
// Method Definition Index: 94401
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ReadOnlySpan_1_t2FC42E74698A85F864327A2F3603A016F223B360 PhysicsBuffer_ToReadOnlySpan_TisContactEndTarget_tE6BBAE8C6CDE91B49A0F4BA4B7FB54332883236A_m861F78494399043A9EBE243F321F948344054CB9 (PhysicsBuffer_tCAD034F191834ECD0CAE25B468D0610D84B68A4D* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		intptr_t* L_0 = (intptr_t*)(&__this->___m_Buffer);
		void* L_1;
		L_1 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline(L_0, NULL);
		int32_t L_2 = __this->___m_Size;
		ReadOnlySpan_1_t2FC42E74698A85F864327A2F3603A016F223B360 L_3;
		memset((&L_3), 0, sizeof(L_3));
		ReadOnlySpan_1__ctor_m10EFD956DD5598E0BB4B432705ECA2DC3D21B5CF_inline((&L_3), L_1, L_2, NULL);
		return L_3;
	}
}
// Method Definition Index: 94401
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ReadOnlySpan_1_t7D0A62688D12B6224D58E7D7EB6BBE34C2B5705B PhysicsBuffer_ToReadOnlySpan_TisJointThresholdTarget_t3D05E6C79F07DBC2277A1980ED540C93D55F60BF_mB799CAEE69F5B8E6EF2D017D55CE25C100D11ACF (PhysicsBuffer_tCAD034F191834ECD0CAE25B468D0610D84B68A4D* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		intptr_t* L_0 = (intptr_t*)(&__this->___m_Buffer);
		void* L_1;
		L_1 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline(L_0, NULL);
		int32_t L_2 = __this->___m_Size;
		ReadOnlySpan_1_t7D0A62688D12B6224D58E7D7EB6BBE34C2B5705B L_3;
		memset((&L_3), 0, sizeof(L_3));
		ReadOnlySpan_1__ctor_m15EED2F0FD0AD432090A6856F982685B71467F81_inline((&L_3), L_1, L_2, NULL);
		return L_3;
	}
}
// Method Definition Index: 94401
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ReadOnlySpan_1_t2239736A651E959D4A4360EBC03DFBCFAE1C9DA6 PhysicsBuffer_ToReadOnlySpan_TisTriggerBeginTarget_t5502949EBCED40452D61487C8D3CCB893F177576_m44C156471D4B8D3BB0599508FA4AA95421795B41 (PhysicsBuffer_tCAD034F191834ECD0CAE25B468D0610D84B68A4D* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		intptr_t* L_0 = (intptr_t*)(&__this->___m_Buffer);
		void* L_1;
		L_1 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline(L_0, NULL);
		int32_t L_2 = __this->___m_Size;
		ReadOnlySpan_1_t2239736A651E959D4A4360EBC03DFBCFAE1C9DA6 L_3;
		memset((&L_3), 0, sizeof(L_3));
		ReadOnlySpan_1__ctor_mA26404126E9D9DE6BE29D5F9EF6C6BC2422A2D88_inline((&L_3), L_1, L_2, NULL);
		return L_3;
	}
}
// Method Definition Index: 94401
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ReadOnlySpan_1_t4A1964D3768FECC83DDD199B546B177020E04377 PhysicsBuffer_ToReadOnlySpan_TisTriggerEndTarget_t403C9C465F01F85B8C5E4BDDDE133CFF7EBD902A_m230051C58A774BEA26D6962E100FEFF0D990A22F (PhysicsBuffer_tCAD034F191834ECD0CAE25B468D0610D84B68A4D* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		intptr_t* L_0 = (intptr_t*)(&__this->___m_Buffer);
		void* L_1;
		L_1 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline(L_0, NULL);
		int32_t L_2 = __this->___m_Size;
		ReadOnlySpan_1_t4A1964D3768FECC83DDD199B546B177020E04377 L_3;
		memset((&L_3), 0, sizeof(L_3));
		ReadOnlySpan_1__ctor_m748A11CB59F4600404CFE970131654050E606631_inline((&L_3), L_1, L_2, NULL);
		return L_3;
	}
}
// Method Definition Index: 94400
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Span_1_t3EBD12B39F51F09620FC7421B894677E0D26E0AD PhysicsBuffer_ToSpan_TisIl2CppFullySharedGenericStruct_m22DF411BC8A0B8ADBE386340363B69D520FEE64C_fshared (PhysicsBuffer_tCAD034F191834ECD0CAE25B468D0610D84B68A4D* __this, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	//<source_info:<no-source>:1>
	{
		intptr_t* L_0 = (intptr_t*)(&__this->___m_Buffer);
		void* L_1;
		L_1 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline(L_0, NULL);
		int32_t L_2 = __this->___m_Size;
		Span_1_t3EBD12B39F51F09620FC7421B894677E0D26E0AD L_3;
		memset((&L_3), 0, sizeof(L_3));
		Span_1__ctor_m2E922F7D304FD1EC1A39BA2A433FAD54064AE45F_inline((&L_3), L_1, L_2, il2cpp_rgctx_method(method->rgctx_data, 0));
		return L_3;
	}
}
// Method Definition Index: 94400
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Span_1_t9F6FBEA217E68146892F6B8BBCE2E2C9E95689A1 PhysicsBuffer_ToSpan_TisTransformWriteTween_t86FB859350EF146AC5D9CB4CA8196377B714E2B7_m2E205B73CBCD92B0B8B173F222A163671DE75E59 (PhysicsBuffer_tCAD034F191834ECD0CAE25B468D0610D84B68A4D* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		intptr_t* L_0 = (intptr_t*)(&__this->___m_Buffer);
		void* L_1;
		L_1 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline(L_0, NULL);
		int32_t L_2 = __this->___m_Size;
		Span_1_t9F6FBEA217E68146892F6B8BBCE2E2C9E95689A1 L_3;
		memset((&L_3), 0, sizeof(L_3));
		Span_1__ctor_m8B358C367FCD4C5DF714C69892BD3F238BC4BE78_inline((&L_3), L_1, L_2, NULL);
		return L_3;
	}
}
// Method Definition Index: 93221
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_DoConvert_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m9027343AE2D5E12E783D960A500BBA8FE5195BBC (bool* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	uint8_t V_0 = 0x0;
	Il2CppChar V_1 = 0x0;
	double V_2 = 0.0;
	int16_t V_3 = 0;
	int32_t V_4 = 0;
	int64_t V_5 = 0;
	int8_t V_6 = 0x0;
	float V_7 = 0.0f;
	String_t* V_8 = NULL;
	uint16_t V_9 = 0;
	uint32_t V_10 = 0;
	uint64_t V_11 = 0;
	{
	}
	{
		bool* L_0 = ___0_source;
		bool* L_1;
		L_1 = UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mFAC64123CDCBD55D7F3EBE960A434127DBAC2DB0_inline(L_0, NULL);
		bool L_2 = (*(bool*)L_1);
		return L_2;
	}
}
// Method Definition Index: 93222
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_DoConvert_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m149761E33DBB5938797158CD2267777889249D20 (uint8_t* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	Il2CppChar V_1 = 0x0;
	double V_2 = 0.0;
	int16_t V_3 = 0;
	int32_t V_4 = 0;
	int64_t V_5 = 0;
	int8_t V_6 = 0x0;
	float V_7 = 0.0f;
	String_t* V_8 = NULL;
	uint16_t V_9 = 0;
	uint32_t V_10 = 0;
	uint64_t V_11 = 0;
	{
	}
	{
		uint8_t* L_0 = ___0_source;
		int32_t L_1 = ((int32_t)*(L_0));
		V_0 = (bool)((!(((uint32_t)L_1) <= ((uint32_t)0)))? 1 : 0);
		bool* L_2;
		L_2 = UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mFAC64123CDCBD55D7F3EBE960A434127DBAC2DB0_inline((&V_0), NULL);
		bool L_3 = (*(bool*)L_2);
		return L_3;
	}
}
// Method Definition Index: 93223
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_DoConvert_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m3DF4ED5D8E7966448749B0EF4789CF9D28790956 (Il2CppChar* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	uint8_t V_1 = 0x0;
	double V_2 = 0.0;
	int16_t V_3 = 0;
	int32_t V_4 = 0;
	int64_t V_5 = 0;
	int8_t V_6 = 0x0;
	float V_7 = 0.0f;
	String_t* V_8 = NULL;
	uint16_t V_9 = 0;
	uint32_t V_10 = 0;
	uint64_t V_11 = 0;
	{
	}
	{
		Il2CppChar* L_0 = ___0_source;
		int32_t L_1 = ((int32_t)*(((uint16_t*)L_0)));
		V_0 = (bool)((!(((uint32_t)L_1) <= ((uint32_t)0)))? 1 : 0);
		bool* L_2;
		L_2 = UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mFAC64123CDCBD55D7F3EBE960A434127DBAC2DB0_inline((&V_0), NULL);
		bool L_3 = (*(bool*)L_2);
		return L_3;
	}
}
// Method Definition Index: 93224
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_DoConvert_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mC66F7E13FEF3C2A3380BBC07D08F03A8782D33CB (double* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	uint8_t V_1 = 0x0;
	Il2CppChar V_2 = 0x0;
	int16_t V_3 = 0;
	int32_t V_4 = 0;
	int64_t V_5 = 0;
	int8_t V_6 = 0x0;
	float V_7 = 0.0f;
	String_t* V_8 = NULL;
	uint16_t V_9 = 0;
	uint32_t V_10 = 0;
	uint64_t V_11 = 0;
	{
	}
	{
		double* L_0 = ___0_source;
		double L_1 = *(L_0);
		V_0 = (bool)((((int32_t)((((double)L_1) == ((double)(0.0)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool* L_2;
		L_2 = UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mFAC64123CDCBD55D7F3EBE960A434127DBAC2DB0_inline((&V_0), NULL);
		bool L_3 = (*(bool*)L_2);
		return L_3;
	}
}
// Method Definition Index: 93225
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_DoConvert_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m89D52A31D7F2F05F0D17A850C58C0C5F8E030B6B (int16_t* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	uint8_t V_1 = 0x0;
	Il2CppChar V_2 = 0x0;
	double V_3 = 0.0;
	int32_t V_4 = 0;
	int64_t V_5 = 0;
	int8_t V_6 = 0x0;
	float V_7 = 0.0f;
	String_t* V_8 = NULL;
	uint16_t V_9 = 0;
	uint32_t V_10 = 0;
	uint64_t V_11 = 0;
	{
	}
	{
		int16_t* L_0 = ___0_source;
		int32_t L_1 = ((int32_t)*(L_0));
		V_0 = (bool)((!(((uint32_t)L_1) <= ((uint32_t)0)))? 1 : 0);
		bool* L_2;
		L_2 = UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mFAC64123CDCBD55D7F3EBE960A434127DBAC2DB0_inline((&V_0), NULL);
		bool L_3 = (*(bool*)L_2);
		return L_3;
	}
}
// Method Definition Index: 93226
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_DoConvert_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m25B619AFC89D9688CFC7B2569ED069D7C20C2994 (int32_t* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	uint8_t V_1 = 0x0;
	Il2CppChar V_2 = 0x0;
	double V_3 = 0.0;
	int16_t V_4 = 0;
	int32_t V_5 = 0;
	int64_t V_6 = 0;
	int8_t V_7 = 0x0;
	float V_8 = 0.0f;
	String_t* V_9 = NULL;
	uint16_t V_10 = 0;
	uint32_t V_11 = 0;
	uint64_t V_12 = 0;
	{
	}
	{
		int32_t* L_0 = ___0_source;
		int32_t L_1 = *(L_0);
		V_0 = (bool)((!(((uint32_t)L_1) <= ((uint32_t)0)))? 1 : 0);
		bool* L_2;
		L_2 = UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mFAC64123CDCBD55D7F3EBE960A434127DBAC2DB0_inline((&V_0), NULL);
		bool L_3 = (*(bool*)L_2);
		return L_3;
	}
}
// Method Definition Index: 93227
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_DoConvert_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mAC18983A5F1A6A7A790401C2B2FD83531E72EBF6 (int64_t* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	uint8_t V_1 = 0x0;
	Il2CppChar V_2 = 0x0;
	double V_3 = 0.0;
	int16_t V_4 = 0;
	int32_t V_5 = 0;
	int64_t V_6 = 0;
	int8_t V_7 = 0x0;
	float V_8 = 0.0f;
	String_t* V_9 = NULL;
	uint16_t V_10 = 0;
	uint32_t V_11 = 0;
	uint64_t V_12 = 0;
	{
	}
	{
		int64_t* L_0 = ___0_source;
		int64_t L_1 = *(L_0);
		int64_t L_2 = (il2cpp_codegen_conv<int64_t,int32_t,int32_t,false,false>(0,NULL));
		V_0 = (bool)((!(((uint64_t)L_1) <= ((uint64_t)L_2)))? 1 : 0);
		bool* L_3;
		L_3 = UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mFAC64123CDCBD55D7F3EBE960A434127DBAC2DB0_inline((&V_0), NULL);
		bool L_4 = (*(bool*)L_3);
		return L_4;
	}
}
// Method Definition Index: 93228
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_DoConvert_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m09B0F2B814F11B8AE2E0C98B2DFC66B096AED85F (int8_t* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	uint8_t V_1 = 0x0;
	Il2CppChar V_2 = 0x0;
	double V_3 = 0.0;
	int16_t V_4 = 0;
	int32_t V_5 = 0;
	int64_t V_6 = 0;
	int8_t V_7 = 0x0;
	float V_8 = 0.0f;
	String_t* V_9 = NULL;
	uint16_t V_10 = 0;
	uint32_t V_11 = 0;
	uint64_t V_12 = 0;
	{
	}
	{
		int8_t* L_0 = ___0_source;
		int32_t L_1 = ((int32_t)*(L_0));
		V_0 = (bool)((!(((uint32_t)L_1) <= ((uint32_t)0)))? 1 : 0);
		bool* L_2;
		L_2 = UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mFAC64123CDCBD55D7F3EBE960A434127DBAC2DB0_inline((&V_0), NULL);
		bool L_3 = (*(bool*)L_2);
		return L_3;
	}
}
// Method Definition Index: 93229
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_DoConvert_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m036744F72FE967803E4F56F626BD5921C272FE91 (float* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	uint8_t V_1 = 0x0;
	Il2CppChar V_2 = 0x0;
	double V_3 = 0.0;
	int16_t V_4 = 0;
	int32_t V_5 = 0;
	int64_t V_6 = 0;
	int8_t V_7 = 0x0;
	float V_8 = 0.0f;
	String_t* V_9 = NULL;
	uint16_t V_10 = 0;
	uint32_t V_11 = 0;
	uint64_t V_12 = 0;
	{
	}
	{
		float* L_0 = ___0_source;
		float L_1 = *(L_0);
		V_0 = (bool)((((int32_t)((((float)L_1) == ((float)(0.0f)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool* L_2;
		L_2 = UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mFAC64123CDCBD55D7F3EBE960A434127DBAC2DB0_inline((&V_0), NULL);
		bool L_3 = (*(bool*)L_2);
		return L_3;
	}
}
// Method Definition Index: 93230
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_DoConvert_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m12F65C97A5D3B2BEDA547C8B1D5B8507A2FB1A2E (String_t** ___0_source, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PrimitivesConverters_TryConvertPrimitiveOrString_TisDouble_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m29A9863FEB29DD171534C86E92808796F4F4451A_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	CHECKED_LOCAL(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	double V_1 = 0.0;
	bool V_2 = false;
	bool V_3 = false;
	uint8_t V_4 = 0x0;
	double V_5 = 0.0;
	uint8_t V_6 = 0x0;
	Il2CppChar V_7 = 0x0;
	double V_8 = 0.0;
	int16_t V_9 = 0;
	double V_10 = 0.0;
	int16_t V_11 = 0;
	int32_t V_12 = 0;
	double V_13 = 0.0;
	int32_t V_14 = 0;
	int64_t V_15 = 0;
	double V_16 = 0.0;
	int64_t V_17 = 0;
	int8_t V_18 = 0x0;
	double V_19 = 0.0;
	int8_t V_20 = 0x0;
	float V_21 = 0.0f;
	double V_22 = 0.0;
	float V_23 = 0.0f;
	uint16_t V_24 = 0;
	double V_25 = 0.0;
	uint16_t V_26 = 0;
	uint32_t V_27 = 0;
	double V_28 = 0.0;
	uint32_t V_29 = 0;
	uint64_t V_30 = 0;
	double V_31 = 0.0;
	uint64_t V_32 = 0;
	{
	}
	{
		String_t** L_0 = ___0_source;
		String_t* L_1 = *(L_0);
		CHECKED_LOCAL_INIT(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticInit,(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_2;
		L_2 = Boolean_TryParse_m417053B6E8D3724D0EED9E87C90D143622158352(L_1, (&V_0), NULL);
		if (!L_2)
		{
			goto IL_0033;
		}
	}
	{
		bool* L_3;
		L_3 = UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mFAC64123CDCBD55D7F3EBE960A434127DBAC2DB0_inline((&V_0), NULL);
		bool L_4 = (*(bool*)L_3);
		return L_4;
	}

IL_0033:
	{
		String_t** L_5 = ___0_source;
		String_t* L_6 = *(L_5);
		bool L_7;
		L_7 = Double_TryParse_m60AD55BC181D70F661BC2A2294E66B5466C3C018(L_6, (&V_1), NULL);
		if (!L_7)
		{
			goto IL_0049;
		}
	}
	{
		bool L_8;
		L_8 = PrimitivesConverters_TryConvertPrimitiveOrString_TisDouble_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m29A9863FEB29DD171534C86E92808796F4F4451A((&V_1), (&V_2), PrimitivesConverters_TryConvertPrimitiveOrString_TisDouble_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m29A9863FEB29DD171534C86E92808796F4F4451A_RuntimeMethod_var);
		if (L_8)
		{
			goto IL_0053;
		}
	}

IL_0049:
	{
		il2cpp_codegen_initobj((&V_3), sizeof(bool));
		bool L_9 = V_3;
		return L_9;
	}

IL_0053:
	{
		bool* L_10;
		L_10 = UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mFAC64123CDCBD55D7F3EBE960A434127DBAC2DB0_inline((&V_2), NULL);
		bool L_11 = (*(bool*)L_10);
		return L_11;
	}
}
// Method Definition Index: 93231
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_DoConvert_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m37E4ADE675B732C53AA44A131ECDDDB9117C2FEF (uint16_t* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	uint8_t V_1 = 0x0;
	Il2CppChar V_2 = 0x0;
	double V_3 = 0.0;
	int16_t V_4 = 0;
	int32_t V_5 = 0;
	int64_t V_6 = 0;
	int8_t V_7 = 0x0;
	float V_8 = 0.0f;
	String_t* V_9 = NULL;
	uint16_t V_10 = 0;
	uint32_t V_11 = 0;
	uint64_t V_12 = 0;
	{
	}
	{
		uint16_t* L_0 = ___0_source;
		int32_t L_1 = ((int32_t)*(L_0));
		V_0 = (bool)((!(((uint32_t)L_1) <= ((uint32_t)0)))? 1 : 0);
		bool* L_2;
		L_2 = UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mFAC64123CDCBD55D7F3EBE960A434127DBAC2DB0_inline((&V_0), NULL);
		bool L_3 = (*(bool*)L_2);
		return L_3;
	}
}
// Method Definition Index: 93232
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_DoConvert_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m1C45A7B312AAB20E4018482DD63528AE0FA8AD7F (uint32_t* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	uint8_t V_1 = 0x0;
	Il2CppChar V_2 = 0x0;
	double V_3 = 0.0;
	int16_t V_4 = 0;
	int32_t V_5 = 0;
	int64_t V_6 = 0;
	int8_t V_7 = 0x0;
	float V_8 = 0.0f;
	String_t* V_9 = NULL;
	uint16_t V_10 = 0;
	uint32_t V_11 = 0;
	uint64_t V_12 = 0;
	{
	}
	{
		uint32_t* L_0 = ___0_source;
		int32_t L_1 = ((int32_t)*(L_0));
		V_0 = (bool)((!(((uint32_t)L_1) <= ((uint32_t)0)))? 1 : 0);
		bool* L_2;
		L_2 = UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mFAC64123CDCBD55D7F3EBE960A434127DBAC2DB0_inline((&V_0), NULL);
		bool L_3 = (*(bool*)L_2);
		return L_3;
	}
}
// Method Definition Index: 93233
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_DoConvert_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mA24D1584B8259D1400DB72B059F6E272F648CD46 (uint64_t* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	uint8_t V_1 = 0x0;
	Il2CppChar V_2 = 0x0;
	double V_3 = 0.0;
	int16_t V_4 = 0;
	int32_t V_5 = 0;
	int64_t V_6 = 0;
	int8_t V_7 = 0x0;
	float V_8 = 0.0f;
	String_t* V_9 = NULL;
	uint16_t V_10 = 0;
	uint32_t V_11 = 0;
	{
	}
	{
		uint64_t* L_0 = ___0_source;
		int64_t L_1 = *(((int64_t*)L_0));
		int64_t L_2 = (il2cpp_codegen_conv<int64_t,int32_t,int32_t,false,false>(0,NULL));
		V_0 = (bool)((!(((uint64_t)L_1) <= ((uint64_t)L_2)))? 1 : 0);
		bool* L_3;
		L_3 = UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mFAC64123CDCBD55D7F3EBE960A434127DBAC2DB0_inline((&V_0), NULL);
		bool L_4 = (*(bool*)L_3);
		return L_4;
	}
}
// Method Definition Index: 93221
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint8_t PrimitivesConverters_DoConvert_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m1D9F1B7A5D81F7D975583BEDDD47FB3FF700DB66 (bool* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	uint8_t V_0 = 0x0;
	Il2CppChar V_1 = 0x0;
	double V_2 = 0.0;
	int16_t V_3 = 0;
	int32_t V_4 = 0;
	int64_t V_5 = 0;
	int8_t V_6 = 0x0;
	float V_7 = 0.0f;
	String_t* V_8 = NULL;
	uint16_t V_9 = 0;
	uint32_t V_10 = 0;
	uint64_t V_11 = 0;
	{
		goto IL_0027;
	}

IL_0027:
	{
	}
	{
		bool* L_0 = ___0_source;
		int32_t L_1 = ((int32_t)*(((uint8_t*)L_0)));
		uint8_t L_2 = (il2cpp_codegen_conv<uint8_t,int32_t,int32_t,false,false>(((!(((uint32_t)L_1) <= ((uint32_t)0)))? 1 : 0),NULL));
		V_0 = L_2;
		uint8_t* L_3;
		L_3 = UnsafeUtility_As_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m3DC6C8431AF46D3B4AD529D400BD9FD0DC961014_inline((&V_0), NULL);
		uint8_t L_4 = (*(uint8_t*)L_3);
		return L_4;
	}
}
// Method Definition Index: 93222
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint8_t PrimitivesConverters_DoConvert_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_mF5EB901165BBA1DD14FB0BA192EDCEEAB74270AA (uint8_t* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	Il2CppChar V_1 = 0x0;
	double V_2 = 0.0;
	int16_t V_3 = 0;
	int32_t V_4 = 0;
	int64_t V_5 = 0;
	int8_t V_6 = 0x0;
	float V_7 = 0.0f;
	String_t* V_8 = NULL;
	uint16_t V_9 = 0;
	uint32_t V_10 = 0;
	uint64_t V_11 = 0;
	{
		goto IL_002e;
	}

IL_002e:
	{
	}
	{
		uint8_t* L_0 = ___0_source;
		uint8_t* L_1;
		L_1 = UnsafeUtility_As_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m3DC6C8431AF46D3B4AD529D400BD9FD0DC961014_inline(L_0, NULL);
		uint8_t L_2 = (*(uint8_t*)L_1);
		return L_2;
	}
}
// Method Definition Index: 93223
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint8_t PrimitivesConverters_DoConvert_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m32C9CA058130C3CD23CF459833CA0B683CB2CA25 (Il2CppChar* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	uint8_t V_1 = 0x0;
	double V_2 = 0.0;
	int16_t V_3 = 0;
	int32_t V_4 = 0;
	int64_t V_5 = 0;
	int8_t V_6 = 0x0;
	float V_7 = 0.0f;
	String_t* V_8 = NULL;
	uint16_t V_9 = 0;
	uint32_t V_10 = 0;
	uint64_t V_11 = 0;
	{
		goto IL_002e;
	}

IL_002e:
	{
	}
	{
		Il2CppChar* L_0 = ___0_source;
		int32_t L_1 = ((int32_t)*(((uint16_t*)L_0)));
		uint8_t L_2 = (il2cpp_codegen_conv<uint8_t,int32_t,int32_t,false,false>(L_1,NULL));
		V_1 = L_2;
		uint8_t* L_3;
		L_3 = UnsafeUtility_As_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m3DC6C8431AF46D3B4AD529D400BD9FD0DC961014_inline((&V_1), NULL);
		uint8_t L_4 = (*(uint8_t*)L_3);
		return L_4;
	}
}
// Method Definition Index: 93224
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint8_t PrimitivesConverters_DoConvert_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_mE3256829F19143C84DDFB7DE5E99CADED21B525F (double* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	uint8_t V_1 = 0x0;
	Il2CppChar V_2 = 0x0;
	int16_t V_3 = 0;
	int32_t V_4 = 0;
	int64_t V_5 = 0;
	int8_t V_6 = 0x0;
	float V_7 = 0.0f;
	String_t* V_8 = NULL;
	uint16_t V_9 = 0;
	uint32_t V_10 = 0;
	uint64_t V_11 = 0;
	{
		goto IL_0039;
	}

IL_0039:
	{
	}
	{
		double* L_0 = ___0_source;
		double L_1 = *(L_0);
		uint8_t L_2 = (il2cpp_codegen_conv<uint8_t,double,double,false,false>(L_1,NULL));
		V_1 = L_2;
		uint8_t* L_3;
		L_3 = UnsafeUtility_As_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m3DC6C8431AF46D3B4AD529D400BD9FD0DC961014_inline((&V_1), NULL);
		uint8_t L_4 = (*(uint8_t*)L_3);
		return L_4;
	}
}
// Method Definition Index: 93225
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint8_t PrimitivesConverters_DoConvert_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_mEBDD863AA99BCA43774A0D46CFD65779C2371387 (int16_t* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	uint8_t V_1 = 0x0;
	Il2CppChar V_2 = 0x0;
	double V_3 = 0.0;
	int32_t V_4 = 0;
	int64_t V_5 = 0;
	int8_t V_6 = 0x0;
	float V_7 = 0.0f;
	String_t* V_8 = NULL;
	uint16_t V_9 = 0;
	uint32_t V_10 = 0;
	uint64_t V_11 = 0;
	{
		goto IL_002e;
	}

IL_002e:
	{
	}
	{
		int16_t* L_0 = ___0_source;
		int32_t L_1 = ((int32_t)*(L_0));
		uint8_t L_2 = (il2cpp_codegen_conv<uint8_t,int32_t,int32_t,false,false>(L_1,NULL));
		V_1 = L_2;
		uint8_t* L_3;
		L_3 = UnsafeUtility_As_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m3DC6C8431AF46D3B4AD529D400BD9FD0DC961014_inline((&V_1), NULL);
		uint8_t L_4 = (*(uint8_t*)L_3);
		return L_4;
	}
}
// Method Definition Index: 93226
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint8_t PrimitivesConverters_DoConvert_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m99856D60B28AB7F7BB78FB2CC353B0449B439D26 (int32_t* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	uint8_t V_1 = 0x0;
	Il2CppChar V_2 = 0x0;
	double V_3 = 0.0;
	int16_t V_4 = 0;
	int32_t V_5 = 0;
	int64_t V_6 = 0;
	int8_t V_7 = 0x0;
	float V_8 = 0.0f;
	String_t* V_9 = NULL;
	uint16_t V_10 = 0;
	uint32_t V_11 = 0;
	uint64_t V_12 = 0;
	{
		goto IL_002e;
	}

IL_002e:
	{
	}
	{
		int32_t* L_0 = ___0_source;
		int32_t L_1 = *(L_0);
		uint8_t L_2 = (il2cpp_codegen_conv<uint8_t,int32_t,int32_t,false,false>(L_1,NULL));
		V_1 = L_2;
		uint8_t* L_3;
		L_3 = UnsafeUtility_As_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m3DC6C8431AF46D3B4AD529D400BD9FD0DC961014_inline((&V_1), NULL);
		uint8_t L_4 = (*(uint8_t*)L_3);
		return L_4;
	}
}
// Method Definition Index: 93227
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint8_t PrimitivesConverters_DoConvert_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_mB68AB17BB4FA9B0767863E482CD15EFB7471C208 (int64_t* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	uint8_t V_1 = 0x0;
	Il2CppChar V_2 = 0x0;
	double V_3 = 0.0;
	int16_t V_4 = 0;
	int32_t V_5 = 0;
	int64_t V_6 = 0;
	int8_t V_7 = 0x0;
	float V_8 = 0.0f;
	String_t* V_9 = NULL;
	uint16_t V_10 = 0;
	uint32_t V_11 = 0;
	uint64_t V_12 = 0;
	{
		goto IL_002f;
	}

IL_002f:
	{
	}
	{
		int64_t* L_0 = ___0_source;
		int64_t L_1 = *(L_0);
		uint8_t L_2 = (il2cpp_codegen_conv<uint8_t,int64_t,int64_t,false,false>(L_1,NULL));
		V_1 = L_2;
		uint8_t* L_3;
		L_3 = UnsafeUtility_As_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m3DC6C8431AF46D3B4AD529D400BD9FD0DC961014_inline((&V_1), NULL);
		uint8_t L_4 = (*(uint8_t*)L_3);
		return L_4;
	}
}
// Method Definition Index: 93228
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint8_t PrimitivesConverters_DoConvert_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m28268368C65727EB799EFC8BA63007367C1CA714 (int8_t* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	uint8_t V_1 = 0x0;
	Il2CppChar V_2 = 0x0;
	double V_3 = 0.0;
	int16_t V_4 = 0;
	int32_t V_5 = 0;
	int64_t V_6 = 0;
	int8_t V_7 = 0x0;
	float V_8 = 0.0f;
	String_t* V_9 = NULL;
	uint16_t V_10 = 0;
	uint32_t V_11 = 0;
	uint64_t V_12 = 0;
	{
		goto IL_002e;
	}

IL_002e:
	{
	}
	{
		int8_t* L_0 = ___0_source;
		int32_t L_1 = ((int32_t)*(L_0));
		uint8_t L_2 = (il2cpp_codegen_conv<uint8_t,int32_t,int32_t,false,false>(L_1,NULL));
		V_1 = L_2;
		uint8_t* L_3;
		L_3 = UnsafeUtility_As_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m3DC6C8431AF46D3B4AD529D400BD9FD0DC961014_inline((&V_1), NULL);
		uint8_t L_4 = (*(uint8_t*)L_3);
		return L_4;
	}
}
// Method Definition Index: 93229
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint8_t PrimitivesConverters_DoConvert_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_mF577073B6AEC787E4E861B6BB90E3007081CE686 (float* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	uint8_t V_1 = 0x0;
	Il2CppChar V_2 = 0x0;
	double V_3 = 0.0;
	int16_t V_4 = 0;
	int32_t V_5 = 0;
	int64_t V_6 = 0;
	int8_t V_7 = 0x0;
	float V_8 = 0.0f;
	String_t* V_9 = NULL;
	uint16_t V_10 = 0;
	uint32_t V_11 = 0;
	uint64_t V_12 = 0;
	{
		goto IL_0035;
	}

IL_0035:
	{
	}
	{
		float* L_0 = ___0_source;
		float L_1 = *(L_0);
		uint8_t L_2 = (il2cpp_codegen_conv<uint8_t,float,float,false,false>(L_1,NULL));
		V_1 = L_2;
		uint8_t* L_3;
		L_3 = UnsafeUtility_As_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m3DC6C8431AF46D3B4AD529D400BD9FD0DC961014_inline((&V_1), NULL);
		uint8_t L_4 = (*(uint8_t*)L_3);
		return L_4;
	}
}
// Method Definition Index: 93230
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint8_t PrimitivesConverters_DoConvert_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m9B13901D54CB804F0D654765920805B858783F96 (String_t** ___0_source, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PrimitivesConverters_TryConvertPrimitiveOrString_TisDouble_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m8FF415C41F9748700137EB247B2399BE6D3629AC_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	//<source_info:<no-source>:1>
	bool V_0 = false;
	double V_1 = 0.0;
	bool V_2 = false;
	uint8_t V_3 = 0x0;
	uint8_t V_4 = 0x0;
	double V_5 = 0.0;
	uint8_t V_6 = 0x0;
	Il2CppChar V_7 = 0x0;
	double V_8 = 0.0;
	int16_t V_9 = 0;
	double V_10 = 0.0;
	int16_t V_11 = 0;
	int32_t V_12 = 0;
	double V_13 = 0.0;
	int32_t V_14 = 0;
	int64_t V_15 = 0;
	double V_16 = 0.0;
	int64_t V_17 = 0;
	int8_t V_18 = 0x0;
	double V_19 = 0.0;
	int8_t V_20 = 0x0;
	float V_21 = 0.0f;
	double V_22 = 0.0;
	float V_23 = 0.0f;
	uint16_t V_24 = 0;
	double V_25 = 0.0;
	uint16_t V_26 = 0;
	uint32_t V_27 = 0;
	double V_28 = 0.0;
	uint32_t V_29 = 0;
	uint64_t V_30 = 0;
	double V_31 = 0.0;
	uint64_t V_32 = 0;
	{
		goto IL_0060;
	}

IL_0060:
	{
	}
	{
		String_t** L_0 = ___0_source;
		String_t* L_1 = *(L_0);
		bool L_2;
		L_2 = Byte_TryParse_mB1716E3B6714F20DF6C1FEDDC4A76AA78D5EA87B(L_1, (&V_4), NULL);
		if (!L_2)
		{
			goto IL_0093;
		}
	}
	{
		uint8_t* L_3;
		L_3 = UnsafeUtility_As_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m3DC6C8431AF46D3B4AD529D400BD9FD0DC961014_inline((&V_4), NULL);
		uint8_t L_4 = (*(uint8_t*)L_3);
		return L_4;
	}

IL_0093:
	{
		String_t** L_5 = ___0_source;
		String_t* L_6 = *(L_5);
		bool L_7;
		L_7 = Double_TryParse_m60AD55BC181D70F661BC2A2294E66B5466C3C018(L_6, (&V_5), NULL);
		if (!L_7)
		{
			goto IL_00a9;
		}
	}
	{
		bool L_8;
		L_8 = PrimitivesConverters_TryConvertPrimitiveOrString_TisDouble_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m8FF415C41F9748700137EB247B2399BE6D3629AC((&V_5), (&V_6), PrimitivesConverters_TryConvertPrimitiveOrString_TisDouble_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m8FF415C41F9748700137EB247B2399BE6D3629AC_RuntimeMethod_var);
		if (L_8)
		{
			goto IL_00b3;
		}
	}

IL_00a9:
	{
		il2cpp_codegen_initobj((&V_3), sizeof(uint8_t));
		uint8_t L_9 = V_3;
		return L_9;
	}

IL_00b3:
	{
		uint8_t* L_10;
		L_10 = UnsafeUtility_As_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m3DC6C8431AF46D3B4AD529D400BD9FD0DC961014_inline((&V_6), NULL);
		uint8_t L_11 = (*(uint8_t*)L_10);
		return L_11;
	}
}
// Method Definition Index: 93231
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint8_t PrimitivesConverters_DoConvert_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_mEF91E40B8997E8935DD25485CAA881E55AEC97A1 (uint16_t* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	uint8_t V_1 = 0x0;
	Il2CppChar V_2 = 0x0;
	double V_3 = 0.0;
	int16_t V_4 = 0;
	int32_t V_5 = 0;
	int64_t V_6 = 0;
	int8_t V_7 = 0x0;
	float V_8 = 0.0f;
	String_t* V_9 = NULL;
	uint16_t V_10 = 0;
	uint32_t V_11 = 0;
	uint64_t V_12 = 0;
	{
		goto IL_002e;
	}

IL_002e:
	{
	}
	{
		uint16_t* L_0 = ___0_source;
		int32_t L_1 = ((int32_t)*(L_0));
		uint8_t L_2 = (il2cpp_codegen_conv<uint8_t,int32_t,int32_t,false,false>(L_1,NULL));
		V_1 = L_2;
		uint8_t* L_3;
		L_3 = UnsafeUtility_As_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m3DC6C8431AF46D3B4AD529D400BD9FD0DC961014_inline((&V_1), NULL);
		uint8_t L_4 = (*(uint8_t*)L_3);
		return L_4;
	}
}
// Method Definition Index: 93232
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint8_t PrimitivesConverters_DoConvert_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_mC7AB336EA1F27C4E4B76DF6C6CA656D88C1FAFDC (uint32_t* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	uint8_t V_1 = 0x0;
	Il2CppChar V_2 = 0x0;
	double V_3 = 0.0;
	int16_t V_4 = 0;
	int32_t V_5 = 0;
	int64_t V_6 = 0;
	int8_t V_7 = 0x0;
	float V_8 = 0.0f;
	String_t* V_9 = NULL;
	uint16_t V_10 = 0;
	uint32_t V_11 = 0;
	uint64_t V_12 = 0;
	{
		goto IL_002e;
	}

IL_002e:
	{
	}
	{
		uint32_t* L_0 = ___0_source;
		int32_t L_1 = ((int32_t)*(L_0));
		uint8_t L_2 = (il2cpp_codegen_conv<uint8_t,int32_t,int32_t,false,false>(L_1,NULL));
		V_1 = L_2;
		uint8_t* L_3;
		L_3 = UnsafeUtility_As_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m3DC6C8431AF46D3B4AD529D400BD9FD0DC961014_inline((&V_1), NULL);
		uint8_t L_4 = (*(uint8_t*)L_3);
		return L_4;
	}
}
// Method Definition Index: 93233
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint8_t PrimitivesConverters_DoConvert_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_mB41620C809A0702F408476A836BD8B081C5F5F76 (uint64_t* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	uint8_t V_1 = 0x0;
	Il2CppChar V_2 = 0x0;
	double V_3 = 0.0;
	int16_t V_4 = 0;
	int32_t V_5 = 0;
	int64_t V_6 = 0;
	int8_t V_7 = 0x0;
	float V_8 = 0.0f;
	String_t* V_9 = NULL;
	uint16_t V_10 = 0;
	uint32_t V_11 = 0;
	{
		goto IL_002f;
	}

IL_002f:
	{
	}
	{
		uint64_t* L_0 = ___0_source;
		int64_t L_1 = *(((int64_t*)L_0));
		uint8_t L_2 = (il2cpp_codegen_conv<uint8_t,int64_t,int64_t,false,false>(L_1,NULL));
		V_1 = L_2;
		uint8_t* L_3;
		L_3 = UnsafeUtility_As_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m3DC6C8431AF46D3B4AD529D400BD9FD0DC961014_inline((&V_1), NULL);
		uint8_t L_4 = (*(uint8_t*)L_3);
		return L_4;
	}
}
// Method Definition Index: 93221
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int16_t PrimitivesConverters_DoConvert_TisInt16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_m6E60594E5DEC517F2531110144CDFDEDF3B46D44 (bool* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	uint8_t V_0 = 0x0;
	Il2CppChar V_1 = 0x0;
	double V_2 = 0.0;
	int16_t V_3 = 0;
	int32_t V_4 = 0;
	int64_t V_5 = 0;
	int8_t V_6 = 0x0;
	float V_7 = 0.0f;
	String_t* V_8 = NULL;
	uint16_t V_9 = 0;
	uint32_t V_10 = 0;
	uint64_t V_11 = 0;
	{
		goto IL_0027;
	}

IL_0027:
	{
		goto IL_0056;
	}

IL_0056:
	{
		goto IL_0085;
	}

IL_0085:
	{
		goto IL_00c6;
	}

IL_00c6:
	{
	}
	{
		bool* L_0 = ___0_source;
		int32_t L_1 = ((int32_t)*(((uint8_t*)L_0)));
		int16_t L_2 = (il2cpp_codegen_conv<int16_t,int32_t,int32_t,false,false>(((!(((uint32_t)L_1) <= ((uint32_t)0)))? 1 : 0),NULL));
		V_3 = L_2;
		int16_t* L_3;
		L_3 = UnsafeUtility_As_TisInt16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_TisInt16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_m79136FE812DC030B796002F8D0127FADB3845447_inline((&V_3), NULL);
		int16_t L_4 = (*(int16_t*)L_3);
		return L_4;
	}
}
// Method Definition Index: 93222
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int16_t PrimitivesConverters_DoConvert_TisInt16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_m36404D92937D0B2561E062BBE4E25C940050A1A1 (uint8_t* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	Il2CppChar V_1 = 0x0;
	double V_2 = 0.0;
	int16_t V_3 = 0;
	int32_t V_4 = 0;
	int64_t V_5 = 0;
	int8_t V_6 = 0x0;
	float V_7 = 0.0f;
	String_t* V_8 = NULL;
	uint16_t V_9 = 0;
	uint32_t V_10 = 0;
	uint64_t V_11 = 0;
	{
		goto IL_002e;
	}

IL_002e:
	{
		goto IL_0055;
	}

IL_0055:
	{
		goto IL_0080;
	}

IL_0080:
	{
		goto IL_00ac;
	}

IL_00ac:
	{
	}
	{
		uint8_t* L_0 = ___0_source;
		int32_t L_1 = ((int32_t)*(L_0));
		V_3 = (int16_t)L_1;
		int16_t* L_2;
		L_2 = UnsafeUtility_As_TisInt16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_TisInt16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_m79136FE812DC030B796002F8D0127FADB3845447_inline((&V_3), NULL);
		int16_t L_3 = (*(int16_t*)L_2);
		return L_3;
	}
}
// Method Definition Index: 93223
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int16_t PrimitivesConverters_DoConvert_TisInt16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_mC89F76CF2D698A8804F5D0C32B85D4416489CBC6 (Il2CppChar* ___0_source, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	bool V_0 = false;
	uint8_t V_1 = 0x0;
	double V_2 = 0.0;
	int16_t V_3 = 0;
	int32_t V_4 = 0;
	int64_t V_5 = 0;
	int8_t V_6 = 0x0;
	float V_7 = 0.0f;
	String_t* V_8 = NULL;
	uint16_t V_9 = 0;
	uint32_t V_10 = 0;
	uint64_t V_11 = 0;
	{
		goto IL_002e;
	}

IL_002e:
	{
		goto IL_005a;
	}

IL_005a:
	{
		goto IL_0081;
	}

IL_0081:
	{
		goto IL_00ad;
	}

IL_00ad:
	{
	}
	{
		Il2CppChar* L_0 = ___0_source;
		int32_t L_1 = ((int32_t)*(((uint16_t*)L_0)));
		int16_t L_2 = (il2cpp_codegen_conv<int16_t,int32_t,int32_t,false,false>(L_1,NULL));
		V_3 = L_2;
		int16_t* L_3;
		L_3 = UnsafeUtility_As_TisInt16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_TisInt16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_m79136FE812DC030B796002F8D0127FADB3845447_inline((&V_3), NULL);
		int16_t L_4 = (*(int16_t*)L_3);
		return L_4;
	}
}
// Method Definition Index: 69200
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void BytePacker_WriteValuePacked_m28A6B72074DC64885C3C9CDD75E9B9F955F8C3C5_inline (FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC ___0_writer, int32_t ___1_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC L_0 = ___0_writer;
		int32_t L_1 = ___1_value;
		BytePacker_WriteValueBitPacked_m510F6322BA0F2C85AF9527A7927FF9B03F0AE613(L_0, L_1, NULL);
		return;
	}
}
// Method Definition Index: 69231
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ByteUnpacker_ReadValuePacked_m7096AA51201BA17A76B47364E7021F390E9A6FD6_inline (FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 ___0_reader, int32_t* ___1_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99 L_0 = ___0_reader;
		int32_t* L_1 = ___1_value;
		ByteUnpacker_ReadValueBitPacked_mC5142499F3BA1F4D8C60EDF335D6C54B0D78C4AC(L_0, L_1, NULL);
		return;
	}
}
// Method Definition Index: 68715
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 NetworkSceneHandle_op_Implicit_m071F9D70086FE159910ABC5BE5358EB76761C589_inline (NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D ___0_handle, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		NetworkSceneHandle_tA610B2527B1ACB80F5DD0846BC521C0319C71E6D L_0 = ___0_handle;
		SceneHandle_t4C3B517546B91EF78A6ED15DDC6C54AB5E03D8A3 L_1 = L_0.___m_Handle;
		return L_1;
	}
}
// Method Definition Index: 69382
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t FastBufferWriter_get_Position_m87642B5268B41B7D15D4E628DF93A5B5776A4B05_inline (FastBufferWriter_tE6AFE9436BD125AF309056A81B70F95625FB96EC* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		WriterHandle_tBDBA7A52860089574884E6269EF80A4ABDA26BE6* L_0 = __this->___Handle;
		NullCheck(L_0);
		int32_t L_1 = L_0->___Position;
		return L_1;
	}
}
// Method Definition Index: 69263
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t FastBufferReader_get_Position_m6B9DC9ECC9F2D943EA0103248E10AB9B95C8F4CF_inline (FastBufferReader_t1FA49C2063B2EAAADB8DE7FF571FF284719D0E99* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		ReaderHandle_t7A818FF1A9ACF79E6D6322AFF494B9FB12C48CC8* L_0 = __this->___Handle;
		NullCheck(L_0);
		int32_t L_1 = L_0->___Position;
		return L_1;
	}
}
// Method Definition Index: 70422
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint32_t FlagStates_GetBitsetRepresentation_m7002081C4C5BD54947BD04940B1FA592C83CEC3B_inline (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	uint32_t V_0 = 0;
	{
		V_0 = 0;
		bool L_0 = __this->___InLocalSpace;
		if (!L_0)
		{
			goto IL_000e;
		}
	}
	{
		uint32_t L_1 = V_0;
		V_0 = ((int32_t)((int32_t)L_1|1));
	}

IL_000e:
	{
		bool L_2 = __this->___HasPositionX;
		if (!L_2)
		{
			goto IL_001a;
		}
	}
	{
		uint32_t L_3 = V_0;
		V_0 = ((int32_t)((int32_t)L_3|2));
	}

IL_001a:
	{
		bool L_4 = __this->___HasPositionY;
		if (!L_4)
		{
			goto IL_0026;
		}
	}
	{
		uint32_t L_5 = V_0;
		V_0 = ((int32_t)((int32_t)L_5|4));
	}

IL_0026:
	{
		bool L_6 = __this->___HasPositionZ;
		if (!L_6)
		{
			goto IL_0032;
		}
	}
	{
		uint32_t L_7 = V_0;
		V_0 = ((int32_t)((int32_t)L_7|8));
	}

IL_0032:
	{
		bool L_8 = __this->___HasRotAngleX;
		if (!L_8)
		{
			goto IL_003f;
		}
	}
	{
		uint32_t L_9 = V_0;
		V_0 = ((int32_t)((int32_t)L_9|((int32_t)16)));
	}

IL_003f:
	{
		bool L_10 = __this->___HasRotAngleY;
		if (!L_10)
		{
			goto IL_004c;
		}
	}
	{
		uint32_t L_11 = V_0;
		V_0 = ((int32_t)((int32_t)L_11|((int32_t)32)));
	}

IL_004c:
	{
		bool L_12 = __this->___HasRotAngleZ;
		if (!L_12)
		{
			goto IL_0059;
		}
	}
	{
		uint32_t L_13 = V_0;
		V_0 = ((int32_t)((int32_t)L_13|((int32_t)64)));
	}

IL_0059:
	{
		bool L_14 = __this->___HasScaleX;
		if (!L_14)
		{
			goto IL_0069;
		}
	}
	{
		uint32_t L_15 = V_0;
		V_0 = ((int32_t)((int32_t)L_15|((int32_t)128)));
	}

IL_0069:
	{
		bool L_16 = __this->___HasScaleY;
		if (!L_16)
		{
			goto IL_0079;
		}
	}
	{
		uint32_t L_17 = V_0;
		V_0 = ((int32_t)((int32_t)L_17|((int32_t)256)));
	}

IL_0079:
	{
		bool L_18 = __this->___HasScaleZ;
		if (!L_18)
		{
			goto IL_0089;
		}
	}
	{
		uint32_t L_19 = V_0;
		V_0 = ((int32_t)((int32_t)L_19|((int32_t)512)));
	}

IL_0089:
	{
		bool L_20 = __this->___IsTeleportingNextFrame;
		if (!L_20)
		{
			goto IL_0099;
		}
	}
	{
		uint32_t L_21 = V_0;
		V_0 = ((int32_t)((int32_t)L_21|((int32_t)1024)));
	}

IL_0099:
	{
		bool L_22 = __this->___UseInterpolation;
		if (!L_22)
		{
			goto IL_00a9;
		}
	}
	{
		uint32_t L_23 = V_0;
		V_0 = ((int32_t)((int32_t)L_23|((int32_t)2048)));
	}

IL_00a9:
	{
		bool L_24 = __this->___QuaternionSync;
		if (!L_24)
		{
			goto IL_00b9;
		}
	}
	{
		uint32_t L_25 = V_0;
		V_0 = ((int32_t)((int32_t)L_25|((int32_t)4096)));
	}

IL_00b9:
	{
		bool L_26 = __this->___QuaternionCompression;
		if (!L_26)
		{
			goto IL_00c9;
		}
	}
	{
		uint32_t L_27 = V_0;
		V_0 = ((int32_t)((int32_t)L_27|((int32_t)8192)));
	}

IL_00c9:
	{
		bool L_28 = __this->___UseHalfFloatPrecision;
		if (!L_28)
		{
			goto IL_00d9;
		}
	}
	{
		uint32_t L_29 = V_0;
		V_0 = ((int32_t)((int32_t)L_29|((int32_t)16384)));
	}

IL_00d9:
	{
		bool L_30 = __this->___IsSynchronizing;
		if (!L_30)
		{
			goto IL_00e9;
		}
	}
	{
		uint32_t L_31 = V_0;
		V_0 = ((int32_t)((int32_t)L_31|((int32_t)32768)));
	}

IL_00e9:
	{
		bool L_32 = __this->___UsePositionSlerp;
		if (!L_32)
		{
			goto IL_00f9;
		}
	}
	{
		uint32_t L_33 = V_0;
		V_0 = ((int32_t)((int32_t)L_33|((int32_t)65536)));
	}

IL_00f9:
	{
		bool L_34 = __this->___IsParented;
		if (!L_34)
		{
			goto IL_0109;
		}
	}
	{
		uint32_t L_35 = V_0;
		V_0 = ((int32_t)((int32_t)L_35|((int32_t)131072)));
	}

IL_0109:
	{
		bool L_36 = __this->___SynchronizeBaseHalfFloat;
		if (!L_36)
		{
			goto IL_0119;
		}
	}
	{
		uint32_t L_37 = V_0;
		V_0 = ((int32_t)((int32_t)L_37|((int32_t)262144)));
	}

IL_0119:
	{
		bool L_38 = __this->___ReliableSequenced;
		if (!L_38)
		{
			goto IL_0129;
		}
	}
	{
		uint32_t L_39 = V_0;
		V_0 = ((int32_t)((int32_t)L_39|((int32_t)524288)));
	}

IL_0129:
	{
		bool L_40 = __this->___UseUnreliableDeltas;
		if (!L_40)
		{
			goto IL_0139;
		}
	}
	{
		uint32_t L_41 = V_0;
		V_0 = ((int32_t)((int32_t)L_41|((int32_t)1048576)));
	}

IL_0139:
	{
		bool L_42 = __this->___UnreliableFrameSync;
		if (!L_42)
		{
			goto IL_0149;
		}
	}
	{
		uint32_t L_43 = V_0;
		V_0 = ((int32_t)((int32_t)L_43|((int32_t)2097152)));
	}

IL_0149:
	{
		bool L_44 = __this->___SwitchTransformSpaceWhenParented;
		if (!L_44)
		{
			goto IL_0159;
		}
	}
	{
		uint32_t L_45 = V_0;
		V_0 = ((int32_t)((int32_t)L_45|((int32_t)4194304)));
	}

IL_0159:
	{
		bool L_46 = __this->___TrackByStateId;
		if (!L_46)
		{
			goto IL_0169;
		}
	}
	{
		uint32_t L_47 = V_0;
		V_0 = ((int32_t)((int32_t)L_47|((int32_t)268435456)));
	}

IL_0169:
	{
		uint32_t L_48 = V_0;
		return L_48;
	}
}
// Method Definition Index: 70423
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void FlagStates_SetStateFromBitset_m88B26BC623EA70281C6F7A973DC460786017B638_inline (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* __this, uint32_t ___0_bitset, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		uint32_t L_0 = ___0_bitset;
		__this->___InLocalSpace = (bool)((!(((uint32_t)((int32_t)((int32_t)L_0&1))) <= ((uint32_t)0)))? 1 : 0);
		uint32_t L_1 = ___0_bitset;
		FlagStates_SetHasPosition_mE51FE437505C4A3EDDEAE595CDAE797026BF6A11_inline(__this, 0, (bool)((!(((uint32_t)((int32_t)((int32_t)L_1&2))) <= ((uint32_t)0)))? 1 : 0), NULL);
		uint32_t L_2 = ___0_bitset;
		FlagStates_SetHasPosition_mE51FE437505C4A3EDDEAE595CDAE797026BF6A11_inline(__this, 1, (bool)((!(((uint32_t)((int32_t)((int32_t)L_2&4))) <= ((uint32_t)0)))? 1 : 0), NULL);
		uint32_t L_3 = ___0_bitset;
		FlagStates_SetHasPosition_mE51FE437505C4A3EDDEAE595CDAE797026BF6A11_inline(__this, 2, (bool)((!(((uint32_t)((int32_t)((int32_t)L_3&8))) <= ((uint32_t)0)))? 1 : 0), NULL);
		uint32_t L_4 = ___0_bitset;
		FlagStates_SetHasRotation_mD915333F46992653C0BB3B7B5795633C2FC44878_inline(__this, 0, (bool)((!(((uint32_t)((int32_t)((int32_t)L_4&((int32_t)16)))) <= ((uint32_t)0)))? 1 : 0), NULL);
		uint32_t L_5 = ___0_bitset;
		FlagStates_SetHasRotation_mD915333F46992653C0BB3B7B5795633C2FC44878_inline(__this, 1, (bool)((!(((uint32_t)((int32_t)((int32_t)L_5&((int32_t)32)))) <= ((uint32_t)0)))? 1 : 0), NULL);
		uint32_t L_6 = ___0_bitset;
		FlagStates_SetHasRotation_mD915333F46992653C0BB3B7B5795633C2FC44878_inline(__this, 2, (bool)((!(((uint32_t)((int32_t)((int32_t)L_6&((int32_t)64)))) <= ((uint32_t)0)))? 1 : 0), NULL);
		uint32_t L_7 = ___0_bitset;
		FlagStates_SetHasScale_m4CA0C4FA4015849D5D5EC76C831DF7EC08A023F3_inline(__this, 0, (bool)((!(((uint32_t)((int32_t)((int32_t)L_7&((int32_t)128)))) <= ((uint32_t)0)))? 1 : 0), NULL);
		uint32_t L_8 = ___0_bitset;
		FlagStates_SetHasScale_m4CA0C4FA4015849D5D5EC76C831DF7EC08A023F3_inline(__this, 1, (bool)((!(((uint32_t)((int32_t)((int32_t)L_8&((int32_t)256)))) <= ((uint32_t)0)))? 1 : 0), NULL);
		uint32_t L_9 = ___0_bitset;
		FlagStates_SetHasScale_m4CA0C4FA4015849D5D5EC76C831DF7EC08A023F3_inline(__this, 2, (bool)((!(((uint32_t)((int32_t)((int32_t)L_9&((int32_t)512)))) <= ((uint32_t)0)))? 1 : 0), NULL);
		uint32_t L_10 = ___0_bitset;
		__this->___IsTeleportingNextFrame = (bool)((!(((uint32_t)((int32_t)((int32_t)L_10&((int32_t)1024)))) <= ((uint32_t)0)))? 1 : 0);
		uint32_t L_11 = ___0_bitset;
		__this->___UseInterpolation = (bool)((!(((uint32_t)((int32_t)((int32_t)L_11&((int32_t)2048)))) <= ((uint32_t)0)))? 1 : 0);
		uint32_t L_12 = ___0_bitset;
		__this->___QuaternionSync = (bool)((!(((uint32_t)((int32_t)((int32_t)L_12&((int32_t)4096)))) <= ((uint32_t)0)))? 1 : 0);
		uint32_t L_13 = ___0_bitset;
		__this->___QuaternionCompression = (bool)((!(((uint32_t)((int32_t)((int32_t)L_13&((int32_t)8192)))) <= ((uint32_t)0)))? 1 : 0);
		uint32_t L_14 = ___0_bitset;
		__this->___UseHalfFloatPrecision = (bool)((!(((uint32_t)((int32_t)((int32_t)L_14&((int32_t)16384)))) <= ((uint32_t)0)))? 1 : 0);
		uint32_t L_15 = ___0_bitset;
		__this->___IsSynchronizing = (bool)((!(((uint32_t)((int32_t)((int32_t)L_15&((int32_t)32768)))) <= ((uint32_t)0)))? 1 : 0);
		uint32_t L_16 = ___0_bitset;
		__this->___UsePositionSlerp = (bool)((!(((uint32_t)((int32_t)((int32_t)L_16&((int32_t)65536)))) <= ((uint32_t)0)))? 1 : 0);
		uint32_t L_17 = ___0_bitset;
		__this->___IsParented = (bool)((!(((uint32_t)((int32_t)((int32_t)L_17&((int32_t)131072)))) <= ((uint32_t)0)))? 1 : 0);
		uint32_t L_18 = ___0_bitset;
		__this->___SynchronizeBaseHalfFloat = (bool)((!(((uint32_t)((int32_t)((int32_t)L_18&((int32_t)262144)))) <= ((uint32_t)0)))? 1 : 0);
		uint32_t L_19 = ___0_bitset;
		__this->___ReliableSequenced = (bool)((!(((uint32_t)((int32_t)((int32_t)L_19&((int32_t)524288)))) <= ((uint32_t)0)))? 1 : 0);
		uint32_t L_20 = ___0_bitset;
		__this->___UseUnreliableDeltas = (bool)((!(((uint32_t)((int32_t)((int32_t)L_20&((int32_t)1048576)))) <= ((uint32_t)0)))? 1 : 0);
		uint32_t L_21 = ___0_bitset;
		__this->___UnreliableFrameSync = (bool)((!(((uint32_t)((int32_t)((int32_t)L_21&((int32_t)2097152)))) <= ((uint32_t)0)))? 1 : 0);
		uint32_t L_22 = ___0_bitset;
		__this->___SwitchTransformSpaceWhenParented = (bool)((!(((uint32_t)((int32_t)((int32_t)L_22&((int32_t)4194304)))) <= ((uint32_t)0)))? 1 : 0);
		uint32_t L_23 = ___0_bitset;
		__this->___TrackByStateId = (bool)((!(((uint32_t)((int32_t)((int32_t)L_23&((int32_t)268435456)))) <= ((uint32_t)0)))? 1 : 0);
		return;
	}
}
// Method Definition Index: 70431
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasPositionChange_mF827577ABA451C60526B23885B255D1285B1FBBF_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_0 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_1 = L_0->___HasPositionChange;
		return L_1;
	}
}
// Method Definition Index: 70445
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_UseHalfFloatPrecision_m0513126B8151A8353AF0931D1E792F9E064C7FA8_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_0 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_1 = L_0->___UseHalfFloatPrecision;
		return L_1;
	}
}
// Method Definition Index: 70428
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasPositionX_mC8E02257F7B924AF10C4E88A21C6DF55264A6451_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_0 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_1 = L_0->___HasPositionX;
		return L_1;
	}
}
// Method Definition Index: 70429
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasPositionY_mB77D3E22968FCB3B1F946A7F963E6AFABF915D89_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_0 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_1 = L_0->___HasPositionY;
		return L_1;
	}
}
// Method Definition Index: 70430
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasPositionZ_m3EB043B0EBA833E145F80474615FA82061165C9B_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_0 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_1 = L_0->___HasPositionZ;
		return L_1;
	}
}
// Method Definition Index: 70440
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_IsTeleportingNextFrame_m7139315A1CE849C8DBB503EA4154E6D71582B254_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_0 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_1 = L_0->___IsTeleportingNextFrame;
		return L_1;
	}
}
// Method Definition Index: 70446
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_IsSynchronizing_m99FE076BE4E9D7AB6F7DAF16523F5B72027269EE_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_0 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_1 = L_0->___IsSynchronizing;
		return L_1;
	}
}
// Method Definition Index: 70435
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasRotAngleChange_m4D900826D7636E38F55B6BEDBD88A61230FEE50A_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_0 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_1 = L_0->___HasRotAngleChange;
		return L_1;
	}
}
// Method Definition Index: 70443
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_QuaternionSync_mBB94E4FD11175FD76DDF0EAEB0210E369F28C747_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_0 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_1 = L_0->___QuaternionSync;
		return L_1;
	}
}
// Method Definition Index: 70444
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_QuaternionCompression_m0473AF4A43B2923E5C2359643E3C7C68DEE6339B_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_0 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_1 = L_0->___QuaternionCompression;
		return L_1;
	}
}
// Method Definition Index: 67172
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint32_t QuaternionCompressor_CompressQuaternion_mDFB8E04C1429D8183D314DAEA13E7725C0FADDAD_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* ___0_quaternion, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	//<source_info:<no-source>:1>
	float V_0 = 0.0f;
	float V_1 = 0.0f;
	float V_2 = 0.0f;
	float V_3 = 0.0f;
	float V_4 = 0.0f;
	uint16_t V_5 = 0;
	uint16_t V_6 = 0;
	uint32_t V_7 = 0;
	int32_t G_B7_0 = 0;
	uint32_t G_B10_0 = 0;
	uint32_t G_B13_0 = 0;
	uint32_t G_B16_0 = 0;
	uint32_t G_B19_0 = 0;
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_0 = ___0_quaternion;
		float L_1;
		L_1 = Quaternion_get_Item_m0B886A8EF3417F3309FB0C681A67A4150B7AA739_inline(L_0, 0, NULL);
		float L_2;
		L_2 = fabsf(L_1);
		V_0 = L_2;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_3 = ___0_quaternion;
		float L_4;
		L_4 = Quaternion_get_Item_m0B886A8EF3417F3309FB0C681A67A4150B7AA739_inline(L_3, 1, NULL);
		float L_5;
		L_5 = fabsf(L_4);
		V_1 = L_5;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_6 = ___0_quaternion;
		float L_7;
		L_7 = Quaternion_get_Item_m0B886A8EF3417F3309FB0C681A67A4150B7AA739_inline(L_6, 2, NULL);
		float L_8;
		L_8 = fabsf(L_7);
		V_2 = L_8;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_9 = ___0_quaternion;
		float L_10;
		L_10 = Quaternion_get_Item_m0B886A8EF3417F3309FB0C681A67A4150B7AA739_inline(L_9, 3, NULL);
		float L_11;
		L_11 = fabsf(L_10);
		V_3 = L_11;
		SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* L_12 = (SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C*)(SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C*)SZArrayNew(SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C_il2cpp_TypeInfo_var, (uint32_t)4);
		SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* L_13 = L_12;
		float L_14 = V_0;
		NullCheck(L_13);
		(L_13)->SetAt(static_cast<il2cpp_array_size_t>(0), (float)L_14);
		SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* L_15 = L_13;
		float L_16 = V_1;
		NullCheck(L_15);
		(L_15)->SetAt(static_cast<il2cpp_array_size_t>(1), (float)L_16);
		SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* L_17 = L_15;
		float L_18 = V_2;
		NullCheck(L_17);
		(L_17)->SetAt(static_cast<il2cpp_array_size_t>(2), (float)L_18);
		SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* L_19 = L_17;
		float L_20 = V_3;
		NullCheck(L_19);
		(L_19)->SetAt(static_cast<il2cpp_array_size_t>(3), (float)L_20);
		float L_21;
		L_21 = Mathf_Max_m870B77F6A5225EC21D9778043F987B9B17D08F6B_inline(L_19, NULL);
		V_4 = L_21;
		float L_22 = V_0;
		float L_23 = V_4;
		if ((((float)L_22) == ((float)L_23)))
		{
			goto IL_0069;
		}
	}
	{
		float L_24 = V_1;
		float L_25 = V_4;
		if ((((float)L_24) == ((float)L_25)))
		{
			goto IL_0066;
		}
	}
	{
		float L_26 = V_2;
		float L_27 = V_4;
		if ((((float)L_26) == ((float)L_27)))
		{
			goto IL_0063;
		}
	}
	{
		G_B7_0 = 3;
		goto IL_006a;
	}

IL_0063:
	{
		G_B7_0 = 2;
		goto IL_006a;
	}

IL_0066:
	{
		G_B7_0 = 1;
		goto IL_006a;
	}

IL_0069:
	{
		G_B7_0 = 0;
	}

IL_006a:
	{
		uint16_t L_28 = (il2cpp_codegen_conv<uint16_t,int32_t,int32_t,false,false>(G_B7_0,NULL));
		V_5 = L_28;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_29 = ___0_quaternion;
		uint16_t L_30 = V_5;
		float L_31;
		L_31 = Quaternion_get_Item_m0B886A8EF3417F3309FB0C681A67A4150B7AA739_inline(L_29, (int32_t)L_30, NULL);
		uint16_t L_32 = (il2cpp_codegen_conv<uint16_t,int32_t,int32_t,false,false>(((((float)L_31) < ((float)(0.0f)))? 1 : 0),NULL));
		V_6 = L_32;
		uint16_t L_33 = V_5;
		V_7 = L_33;
		uint16_t L_34 = V_5;
		if (L_34)
		{
			goto IL_008b;
		}
	}
	{
		uint32_t L_35 = V_7;
		G_B10_0 = L_35;
		goto IL_00b9;
	}

IL_008b:
	{
		uint32_t L_36 = V_7;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_37 = ___0_quaternion;
		float L_38;
		L_38 = Quaternion_get_Item_m0B886A8EF3417F3309FB0C681A67A4150B7AA739_inline(L_37, 0, NULL);
		uint16_t L_39 = (il2cpp_codegen_conv<uint16_t,int32_t,int32_t,false,false>(((((float)L_38) < ((float)(0.0f)))? 1 : 0),NULL));
		uint16_t L_40 = V_6;
		uint16_t L_41 = (il2cpp_codegen_conv<uint16_t,int32_t,int32_t,false,false>(((((int32_t)((((int32_t)L_39) == ((int32_t)L_40))? 1 : 0)) == ((int32_t)0))? 1 : 0),NULL));
		float L_42 = V_0;
		float L_43;
		L_43 = bankers_roundf(((float)il2cpp_codegen_multiply((722.663147f), L_42)));
		uint16_t L_44 = (il2cpp_codegen_conv<uint16_t,float,float,false,false>(L_43,NULL));
		G_B10_0 = ((uint32_t)(((int32_t)(((int32_t)(((int32_t)((int32_t)L_36<<((int32_t)10)))|((int32_t)((int32_t)L_41<<((int32_t)9)))))|(int32_t)L_44))));
	}

IL_00b9:
	{
		V_7 = G_B10_0;
		uint16_t L_45 = V_5;
		if ((!(((uint32_t)1) == ((uint32_t)L_45))))
		{
			goto IL_00c4;
		}
	}
	{
		uint32_t L_46 = V_7;
		G_B13_0 = L_46;
		goto IL_00f2;
	}

IL_00c4:
	{
		uint32_t L_47 = V_7;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_48 = ___0_quaternion;
		float L_49;
		L_49 = Quaternion_get_Item_m0B886A8EF3417F3309FB0C681A67A4150B7AA739_inline(L_48, 1, NULL);
		uint16_t L_50 = (il2cpp_codegen_conv<uint16_t,int32_t,int32_t,false,false>(((((float)L_49) < ((float)(0.0f)))? 1 : 0),NULL));
		uint16_t L_51 = V_6;
		uint16_t L_52 = (il2cpp_codegen_conv<uint16_t,int32_t,int32_t,false,false>(((((int32_t)((((int32_t)L_50) == ((int32_t)L_51))? 1 : 0)) == ((int32_t)0))? 1 : 0),NULL));
		float L_53 = V_1;
		float L_54;
		L_54 = bankers_roundf(((float)il2cpp_codegen_multiply((722.663147f), L_53)));
		uint16_t L_55 = (il2cpp_codegen_conv<uint16_t,float,float,false,false>(L_54,NULL));
		G_B13_0 = ((uint32_t)(((int32_t)(((int32_t)(((int32_t)((int32_t)L_47<<((int32_t)10)))|((int32_t)((int32_t)L_52<<((int32_t)9)))))|(int32_t)L_55))));
	}

IL_00f2:
	{
		V_7 = G_B13_0;
		uint16_t L_56 = V_5;
		if ((!(((uint32_t)2) == ((uint32_t)L_56))))
		{
			goto IL_00fd;
		}
	}
	{
		uint32_t L_57 = V_7;
		G_B16_0 = L_57;
		goto IL_012b;
	}

IL_00fd:
	{
		uint32_t L_58 = V_7;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_59 = ___0_quaternion;
		float L_60;
		L_60 = Quaternion_get_Item_m0B886A8EF3417F3309FB0C681A67A4150B7AA739_inline(L_59, 2, NULL);
		uint16_t L_61 = (il2cpp_codegen_conv<uint16_t,int32_t,int32_t,false,false>(((((float)L_60) < ((float)(0.0f)))? 1 : 0),NULL));
		uint16_t L_62 = V_6;
		uint16_t L_63 = (il2cpp_codegen_conv<uint16_t,int32_t,int32_t,false,false>(((((int32_t)((((int32_t)L_61) == ((int32_t)L_62))? 1 : 0)) == ((int32_t)0))? 1 : 0),NULL));
		float L_64 = V_2;
		float L_65;
		L_65 = bankers_roundf(((float)il2cpp_codegen_multiply((722.663147f), L_64)));
		uint16_t L_66 = (il2cpp_codegen_conv<uint16_t,float,float,false,false>(L_65,NULL));
		G_B16_0 = ((uint32_t)(((int32_t)(((int32_t)(((int32_t)((int32_t)L_58<<((int32_t)10)))|((int32_t)((int32_t)L_63<<((int32_t)9)))))|(int32_t)L_66))));
	}

IL_012b:
	{
		V_7 = G_B16_0;
		uint16_t L_67 = V_5;
		if ((!(((uint32_t)3) == ((uint32_t)L_67))))
		{
			goto IL_0136;
		}
	}
	{
		uint32_t L_68 = V_7;
		G_B19_0 = L_68;
		goto IL_0164;
	}

IL_0136:
	{
		uint32_t L_69 = V_7;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_70 = ___0_quaternion;
		float L_71;
		L_71 = Quaternion_get_Item_m0B886A8EF3417F3309FB0C681A67A4150B7AA739_inline(L_70, 3, NULL);
		uint16_t L_72 = (il2cpp_codegen_conv<uint16_t,int32_t,int32_t,false,false>(((((float)L_71) < ((float)(0.0f)))? 1 : 0),NULL));
		uint16_t L_73 = V_6;
		uint16_t L_74 = (il2cpp_codegen_conv<uint16_t,int32_t,int32_t,false,false>(((((int32_t)((((int32_t)L_72) == ((int32_t)L_73))? 1 : 0)) == ((int32_t)0))? 1 : 0),NULL));
		float L_75 = V_3;
		float L_76;
		L_76 = bankers_roundf(((float)il2cpp_codegen_multiply((722.663147f), L_75)));
		uint16_t L_77 = (il2cpp_codegen_conv<uint16_t,float,float,false,false>(L_76,NULL));
		G_B19_0 = ((uint32_t)(((int32_t)(((int32_t)(((int32_t)((int32_t)L_69<<((int32_t)10)))|((int32_t)((int32_t)L_74<<((int32_t)9)))))|(int32_t)L_77))));
	}

IL_0164:
	{
		V_7 = G_B19_0;
		uint32_t L_78 = V_7;
		return L_78;
	}
}
// Method Definition Index: 67173
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void QuaternionCompressor_DecompressQuaternion_mDABA28208E32355842F5BFA792A08813DBE82F51_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* ___0_quaternion, uint32_t ___1_compressed, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	int32_t V_0 = 0;
	float V_1 = 0.0f;
	int32_t V_2 = 0;
	int32_t G_B4_0 = 0;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* G_B4_1 = NULL;
	int32_t G_B3_0 = 0;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* G_B3_1 = NULL;
	float G_B5_0 = 0.0f;
	int32_t G_B5_1 = 0;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* G_B5_2 = NULL;
	{
		uint32_t L_0 = ___1_compressed;
		V_0 = ((int32_t)((uint32_t)L_0>>((int32_t)30)));
		V_1 = (0.0f);
		V_2 = 3;
		goto IL_005c;
	}

IL_000f:
	{
		int32_t L_1 = V_2;
		int32_t L_2 = V_0;
		if ((((int32_t)L_1) == ((int32_t)L_2)))
		{
			goto IL_0058;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_3 = ___0_quaternion;
		int32_t L_4 = V_2;
		uint32_t L_5 = ___1_compressed;
		if ((!(((uint32_t)((int32_t)((int32_t)L_5&((int32_t)512)))) <= ((uint32_t)0))))
		{
			G_B4_0 = L_4;
			G_B4_1 = L_3;
			goto IL_0026;
		}
		G_B3_0 = L_4;
		G_B3_1 = L_3;
	}
	{
		G_B5_0 = (1.0f);
		G_B5_1 = G_B3_0;
		G_B5_2 = G_B3_1;
		goto IL_002b;
	}

IL_0026:
	{
		G_B5_0 = (-1.0f);
		G_B5_1 = G_B4_0;
		G_B5_2 = G_B4_1;
	}

IL_002b:
	{
		uint32_t L_6 = ___1_compressed;
		double L_7 = (il2cpp_codegen_conv<double,int32_t,int32_t,false,true>(((int32_t)((int32_t)L_6&((int32_t)511))),NULL));
		float L_8 = (il2cpp_codegen_conv<float,double,double,false,false>(L_7,NULL));
		Quaternion_set_Item_mFEF628DD58AC71A1E712A6F3F9642D5DA00675CE_inline(G_B5_2, G_B5_1, ((float)il2cpp_codegen_multiply(G_B5_0, ((float)il2cpp_codegen_multiply(L_8, (0.00138377061f))))), NULL);
		float L_9 = V_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_10 = ___0_quaternion;
		int32_t L_11 = V_2;
		float L_12;
		L_12 = Quaternion_get_Item_m0B886A8EF3417F3309FB0C681A67A4150B7AA739_inline(L_10, L_11, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_13 = ___0_quaternion;
		int32_t L_14 = V_2;
		float L_15;
		L_15 = Quaternion_get_Item_m0B886A8EF3417F3309FB0C681A67A4150B7AA739_inline(L_13, L_14, NULL);
		V_1 = ((float)il2cpp_codegen_add(L_9, ((float)il2cpp_codegen_multiply(L_12, L_15))));
		uint32_t L_16 = ___1_compressed;
		___1_compressed = ((int32_t)((uint32_t)L_16>>((int32_t)10)));
	}

IL_0058:
	{
		int32_t L_17 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_subtract(L_17, 1));
	}

IL_005c:
	{
		int32_t L_18 = V_2;
		if ((((int32_t)L_18) >= ((int32_t)0)))
		{
			goto IL_000f;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_19 = ___0_quaternion;
		int32_t L_20 = V_0;
		float L_21 = V_1;
		float L_22;
		L_22 = sqrtf(((float)il2cpp_codegen_subtract((1.0f), L_21)));
		Quaternion_set_Item_mFEF628DD58AC71A1E712A6F3F9642D5DA00675CE_inline(L_19, L_20, L_22, NULL);
		return;
	}
}
// Method Definition Index: 70097
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void HalfVector4_UpdateFrom_m49F84D6FA68D9025729B9AE5BED74C42FC1C2A4D_inline (HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD* __this, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* ___0_quaternion, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_0 = ___0_quaternion;
		float L_1 = L_0->___x;
		half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 L_2;
		L_2 = math_half_mF2B3098B2CDE13073D12FE17D4C55A7EF032C6C7_inline(L_1, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_3 = ___0_quaternion;
		float L_4 = L_3->___y;
		half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 L_5;
		L_5 = math_half_mF2B3098B2CDE13073D12FE17D4C55A7EF032C6C7_inline(L_4, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_6 = ___0_quaternion;
		float L_7 = L_6->___z;
		half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 L_8;
		L_8 = math_half_mF2B3098B2CDE13073D12FE17D4C55A7EF032C6C7_inline(L_7, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_9 = ___0_quaternion;
		float L_10 = L_9->___w;
		half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 L_11;
		L_11 = math_half_mF2B3098B2CDE13073D12FE17D4C55A7EF032C6C7_inline(L_10, NULL);
		half4_t04B1BC17C3559EC70A5CA2394C7C41B480EA83D8 L_12;
		L_12 = math_half4_m377DDE973EE37D2127BA2577A2BCB56884A18E83_inline(L_2, L_5, L_8, L_11, NULL);
		__this->___Axis = L_12;
		return;
	}
}
// Method Definition Index: 70095
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 HalfVector4_ToQuaternion_m2A8121C41C193D8B2BE815FE6C741057B4BD85C5_inline (HalfVector4_t493672846617D0E05AE7C0B3E38E7B460948A1BD* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		half4_t04B1BC17C3559EC70A5CA2394C7C41B480EA83D8 L_0 = __this->___Axis;
		float4_t545A994996126766890C1F28B43EA823F2410190 L_1;
		L_1 = float4_op_Implicit_mFC36DB25B838CA0D0D0BED5E4D89B1BE75F8212A_inline(L_0, NULL);
		quaternion_t9C8C2916B7359C174B215BBB41F290ABCBEA8AEA L_2;
		L_2 = math_quaternion_mE62A8FC9087230BEA736EDFFF8E08B49A3E1BEC4_inline(L_1, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_3;
		L_3 = Quaternion_op_Implicit_m89F4373AD134797808033DCACE56E43E7829CF1E_inline(L_2, NULL);
		return L_3;
	}
}
// Method Definition Index: 70432
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasRotAngleX_m2017FDEB7C6355F80DCAD0258AA5486D6FBDC816_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_0 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_1 = L_0->___HasRotAngleX;
		return L_1;
	}
}
// Method Definition Index: 70433
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasRotAngleY_m1D53E40810F158FDFEEAC32A1487E63ABC5CB040_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_0 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_1 = L_0->___HasRotAngleY;
		return L_1;
	}
}
// Method Definition Index: 70434
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasRotAngleZ_m5B23DA8ED870129BF35C9A82B7776605C248DE04_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_0 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_1 = L_0->___HasRotAngleZ;
		return L_1;
	}
}
// Method Definition Index: 70081
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 HalfVector3_ToVector3_m0D9B03E9618FA457A3A527E30AA765EB4093D0D1_inline (HalfVector3_t921D176C4A9C03F0C05F55B8440B72BB3730EC02* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_1;
	memset((&V_1), 0, sizeof(V_1));
	int32_t V_2 = 0;
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0;
		L_0 = Vector3_get_zero_m0C1249C3F25B1C70EAD3CC8B31259975A457AE39_inline(NULL);
		V_0 = L_0;
		half3_tAC3065568DE0CD35A46DE11D367236E8FB7BEA07 L_1 = __this->___Axis;
		float3_t7600B73F092B37F484B12910A5269F30C778D31E L_2;
		L_2 = math_float3_mBC35F669739DF837407D396F2219211EC69F513A_inline(L_1, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3;
		L_3 = Vector3_op_Implicit_m67D7F2AD018B7F0B44E10CF164D63A4FB32E6B7D_inline(L_2, NULL);
		V_1 = L_3;
		V_2 = 0;
		goto IL_003d;
	}

IL_001b:
	{
		bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02* L_4 = (bool3_t441AC74ECEF37A02C7F99EEE17436B76FCF27B02*)(&__this->___AxisToSynchronize);
		int32_t L_5 = V_2;
		bool L_6;
		L_6 = bool3_get_Item_mFE78E2B8E00D439EFDAB96EFD34486010C0EAECB(L_4, L_5, NULL);
		if (!L_6)
		{
			goto IL_0039;
		}
	}
	{
		int32_t L_7 = V_2;
		int32_t L_8 = V_2;
		float L_9;
		L_9 = Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_inline((&V_1), L_8, NULL);
		Vector3_set_Item_m79136861DEC5862CE7EC20AB3B0EF10A3957CEC3_inline((&V_0), L_7, L_9, NULL);
	}

IL_0039:
	{
		int32_t L_10 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_10, 1));
	}

IL_003d:
	{
		int32_t L_11 = V_2;
		if ((((int32_t)L_11) < ((int32_t)3)))
		{
			goto IL_001b;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12 = V_0;
		return L_12;
	}
}
// Method Definition Index: 70439
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasScaleChange_mD5FBA90EF892DC24F087B409A4A4F04178E955F7_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_0 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_1 = L_0->___HasScaleChange;
		return L_1;
	}
}
// Method Definition Index: 70436
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasScaleX_m82B5E6E8FD2A17E31F8B4179124227E34D190756_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_0 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_1 = L_0->___HasScaleX;
		return L_1;
	}
}
// Method Definition Index: 70437
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasScaleY_mC709C18060AFD0D5944B749FAE96A82F8B078821_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_0 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_1 = L_0->___HasScaleY;
		return L_1;
	}
}
// Method Definition Index: 70438
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool NetworkTransformState_get_HasScaleZ_m812D411158FC2B56DFE0BC3EA77A999220F52FD8_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* L_0 = (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C*)(&__this->___FlagStates);
		bool L_1 = L_0->___HasScaleZ;
		return L_1;
	}
}
// Method Definition Index: 43344
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, int32_t ___0_index, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		int32_t L_0 = ___0_index;
		switch (L_0)
		{
			case 0:
			{
				goto IL_0014;
			}
			case 1:
			{
				goto IL_001b;
			}
			case 2:
			{
				goto IL_0022;
			}
		}
	}
	{
		goto IL_0029;
	}

IL_0014:
	{
		float L_1 = __this->___x;
		return L_1;
	}

IL_001b:
	{
		float L_2 = __this->___y;
		return L_2;
	}

IL_0022:
	{
		float L_3 = __this->___z;
		return L_3;
	}

IL_0029:
	{
		IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82* L_4 = (IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82_il2cpp_TypeInfo_var)));
		IndexOutOfRangeException__ctor_mFD06819F05B815BE2D6E826D4E04F4C449D0A425(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral27C7727EAAAD675C621F6257F2BD5190CE343979)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_RuntimeMethod_var)));
	}
}
// Method Definition Index: 70426
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void NetworkTransformState_set_LastSerializedSize_m495ABA7CDD6AC0B7900EF02669F839F002427BF2_inline (NetworkTransformState_tCCC77820160AFE28825DDD9C3F090B523CA8F5ED* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		int32_t L_0 = ___0_value;
		__this->___U3CLastSerializedSizeU3Ek__BackingField = L_0;
		return;
	}
}
// Method Definition Index: 3923
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool IntPtr_op_Equality_m7D9CDCDE9DC2A0C2C614633F4921E90187FAB271_inline (intptr_t ___0_value1, intptr_t ___1_value2, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		intptr_t L_0 = ___0_value1;
		intptr_t L_1 = ___1_value2;
		return (bool)((((intptr_t)L_0) == ((intptr_t)L_1))? 1 : 0);
	}
}
// Method Definition Index: 44200
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR GCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC MarshalledUnityObject_FromIntPtrUnsafe_m1C5AE0FB7CD1978A8387B0081DB909BAAC2324C3_inline (intptr_t ___0_gcHandle, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		GCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC* L_0;
		L_0 = UnsafeUtility_As_TisIntPtr_t_TisGCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC_mD94F597CB91662C823496DA9FA9A7CF908734A78_inline((&___0_gcHandle), NULL);
		GCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC L_1 = (*(GCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC*)L_0);
		return L_1;
	}
}
// Method Definition Index: 8204
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* GCHandle_get_Target_m481F9508DA5E384D33CD1F4450060DC56BBD4CD5_inline (GCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		bool L_0;
		L_0 = GCHandle_get_IsAllocated_m241908103D8D867E11CCAB73C918729825E86843_inline(__this, NULL);
		if (L_0)
		{
			goto IL_0013;
		}
	}
	{
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_1 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_1, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral4EBC86E0EACFCA522AEB82874860D0E248D782A5)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&GCHandle_get_Target_m481F9508DA5E384D33CD1F4450060DC56BBD4CD5_RuntimeMethod_var)));
	}

IL_0013:
	{
		intptr_t L_2 = __this->___handle;
		bool L_3;
		L_3 = GCHandle_CanDereferenceHandle_mAAAC42D1268CEF3FDD040A3D1574773D08140579_inline(L_2, NULL);
		if (!L_3)
		{
			goto IL_002c;
		}
	}
	{
		intptr_t L_4 = __this->___handle;
		RuntimeObject* L_5;
		L_5 = GCHandle_GetRef_mAC7E58E62417209DC41C99F66BA70F0C3AA18DA8_inline(L_4, NULL);
		return L_5;
	}

IL_002c:
	{
		intptr_t L_6 = __this->___handle;
		RuntimeObject* L_7;
		L_7 = GCHandle_GetTarget_mE0AF851834410E2AEA6285B2497751570236C794(L_6, NULL);
		return L_7;
	}
}
// Method Definition Index: 76980
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785* LambdaExpression_get_Body_m161E156442547AE8A6837C5AE065BD93345451DE_inline (LambdaExpression_tD26FB6AEAD01B2EBB668CDEAFAAFA4948697300E* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		Expression_t70AA908ECBD33E94249BF235E4EBB0F831AD8785* L_0 = __this->____body;
		return L_0;
	}
}
// Method Definition Index: 3920
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void* IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline (intptr_t* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		intptr_t L_0 = *__this;
		return (void*)(L_0);
	}
}
// Method Definition Index: 44197
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR intptr_t MarshalledUnityObject_MarshalNotNull_TisIl2CppSharedGenericObject_mCE897EC9A79983B4B1E6E2C8342452256309044A_gshared_inline (Il2CppSharedGenericObject* ___0_obj, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		Il2CppSharedGenericObject* L_0 = ___0_obj;
		NullCheck(L_0);
		intptr_t L_1 = ((Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)L_0)->___m_CachedPtr;
		return L_1;
	}
}
// Method Definition Index: 30315
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t DynamicArray_1_get_size_m128222BE63C9931B08CD38DF32B858CD1CD4926D_fshared_inline (DynamicArray_1_tFD6392EE4EAA442D167A921C9964FD9C17FDCDE0* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		int32_t L_0 = __this->___U3CsizeU3Ek__BackingField;
		return L_0;
	}
}
// Method Definition Index: 2388
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ReadOnlySpan_1__ctor_mD031F18A4CFBB5CBC861231C3D6E56106D809509_fshared_inline (ReadOnlySpan_1_tC416A5627E04F69CA2947A2A13F0A1DF096CABAC* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) 
{
	CHECKED_LOCAL(classRgctxInit);
	CHECKED_LOCAL(Type_t_StaticInit);
	//<source_info:<no-source>:1>
	{
		bool L_0;
		L_0 = il2cpp_codegen_is_reference_or_contains_references(il2cpp_rgctx_method(CHECKED_LOCAL_INIT_PARAM(classRgctxInit,(il2cpp_codegen_method_rgctx(method)),il2cpp_codegen_initialized_method_rgctx,(method)), 2));
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(CHECKED_LOCAL_INIT_PARAM(classRgctxInit,(il2cpp_codegen_method_rgctx(method)),il2cpp_codegen_initialized_method_rgctx,(method)), 3)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		ThrowHelper_ThrowInvalidTypeWithPointersNotSupported_m5707DE408588F6EAC3FC7D10F9520308CF8C8CCF(L_2, NULL);
	}

IL_0016:
	{
		int32_t L_3 = ___1_length;
		if ((((int32_t)L_3) >= ((int32_t)0)))
		{
			goto IL_001f;
		}
	}
	{
		ThrowHelper_ThrowArgumentOutOfRangeException_mD7D90276EDCDF9394A8EA635923E3B48BB71BD56(NULL);
	}

IL_001f:
	{
		void* L_4 = ___0_pointer;
		Il2CppFullySharedGenericAny* L_5;
		L_5 = il2cpp_unsafe_as_ref<Il2CppFullySharedGenericAny>((uint8_t*)L_4);
		ByReference_1_t607C1F3BC28B0E21B969461CDB0720FB01A82141 L_6;
		memset((&L_6), 0, sizeof(L_6));
		il2cpp_codegen_by_reference_constructor((Il2CppByReference*)(&L_6), L_5);
		__this->____pointer = L_6;
		int32_t L_7 = ___1_length;
		__this->____length = L_7;
		return;
	}
}
// Method Definition Index: 2388
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ReadOnlySpan_1__ctor_mD692C6AD4A813B80EF4C2C650DA20A01BAB8B900_inline (ReadOnlySpan_1_t7C8438B00110311A3FFF078F848928218D9D79F1* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		goto IL_0016;
	}

IL_0016:
	{
		int32_t L_0 = ___1_length;
		if ((((int32_t)L_0) >= ((int32_t)0)))
		{
			goto IL_001f;
		}
	}
	{
		ThrowHelper_ThrowArgumentOutOfRangeException_mD7D90276EDCDF9394A8EA635923E3B48BB71BD56(NULL);
	}

IL_001f:
	{
		void* L_1 = ___0_pointer;
		BodyUpdateTarget_t6013C0FBA9A3E7A8E68F98F01A1B3EA92F574D84* L_2;
		L_2 = il2cpp_unsafe_as_ref<BodyUpdateTarget_t6013C0FBA9A3E7A8E68F98F01A1B3EA92F574D84>((uint8_t*)L_1);
		ByReference_1_t3FCA8FF1FA32CFC8B394F6C061E343A0D3701912 L_3;
		memset((&L_3), 0, sizeof(L_3));
		il2cpp_codegen_by_reference_constructor((Il2CppByReference*)(&L_3), L_2);
		__this->____pointer = L_3;
		int32_t L_4 = ___1_length;
		__this->____length = L_4;
		return;
	}
}
// Method Definition Index: 2388
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ReadOnlySpan_1__ctor_m84B3CCED99878FDE74473A0EE7D051C8467D541A_inline (ReadOnlySpan_1_tD1C684B7FBBE6B196C3D9C25D26C14087DDACC42* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		goto IL_0016;
	}

IL_0016:
	{
		int32_t L_0 = ___1_length;
		if ((((int32_t)L_0) >= ((int32_t)0)))
		{
			goto IL_001f;
		}
	}
	{
		ThrowHelper_ThrowArgumentOutOfRangeException_mD7D90276EDCDF9394A8EA635923E3B48BB71BD56(NULL);
	}

IL_001f:
	{
		void* L_1 = ___0_pointer;
		ContactBeginTarget_t56AE151974F2573AEE7A94C0033B3D0F654D58CC* L_2;
		L_2 = il2cpp_unsafe_as_ref<ContactBeginTarget_t56AE151974F2573AEE7A94C0033B3D0F654D58CC>((uint8_t*)L_1);
		ByReference_1_t94B9C7E612FAA889D668D045B2EC5F1DBF3AFFF9 L_3;
		memset((&L_3), 0, sizeof(L_3));
		il2cpp_codegen_by_reference_constructor((Il2CppByReference*)(&L_3), L_2);
		__this->____pointer = L_3;
		int32_t L_4 = ___1_length;
		__this->____length = L_4;
		return;
	}
}
// Method Definition Index: 2388
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ReadOnlySpan_1__ctor_m10EFD956DD5598E0BB4B432705ECA2DC3D21B5CF_inline (ReadOnlySpan_1_t2FC42E74698A85F864327A2F3603A016F223B360* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		goto IL_0016;
	}

IL_0016:
	{
		int32_t L_0 = ___1_length;
		if ((((int32_t)L_0) >= ((int32_t)0)))
		{
			goto IL_001f;
		}
	}
	{
		ThrowHelper_ThrowArgumentOutOfRangeException_mD7D90276EDCDF9394A8EA635923E3B48BB71BD56(NULL);
	}

IL_001f:
	{
		void* L_1 = ___0_pointer;
		ContactEndTarget_tE6BBAE8C6CDE91B49A0F4BA4B7FB54332883236A* L_2;
		L_2 = il2cpp_unsafe_as_ref<ContactEndTarget_tE6BBAE8C6CDE91B49A0F4BA4B7FB54332883236A>((uint8_t*)L_1);
		ByReference_1_t4A0B0D8287F5D040285FB49C3AA25A8EE38D5B23 L_3;
		memset((&L_3), 0, sizeof(L_3));
		il2cpp_codegen_by_reference_constructor((Il2CppByReference*)(&L_3), L_2);
		__this->____pointer = L_3;
		int32_t L_4 = ___1_length;
		__this->____length = L_4;
		return;
	}
}
// Method Definition Index: 2388
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ReadOnlySpan_1__ctor_m15EED2F0FD0AD432090A6856F982685B71467F81_inline (ReadOnlySpan_1_t7D0A62688D12B6224D58E7D7EB6BBE34C2B5705B* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		goto IL_0016;
	}

IL_0016:
	{
		int32_t L_0 = ___1_length;
		if ((((int32_t)L_0) >= ((int32_t)0)))
		{
			goto IL_001f;
		}
	}
	{
		ThrowHelper_ThrowArgumentOutOfRangeException_mD7D90276EDCDF9394A8EA635923E3B48BB71BD56(NULL);
	}

IL_001f:
	{
		void* L_1 = ___0_pointer;
		JointThresholdTarget_t3D05E6C79F07DBC2277A1980ED540C93D55F60BF* L_2;
		L_2 = il2cpp_unsafe_as_ref<JointThresholdTarget_t3D05E6C79F07DBC2277A1980ED540C93D55F60BF>((uint8_t*)L_1);
		ByReference_1_tA7727FC82C1D779EE2802A1968C3FFC569152294 L_3;
		memset((&L_3), 0, sizeof(L_3));
		il2cpp_codegen_by_reference_constructor((Il2CppByReference*)(&L_3), L_2);
		__this->____pointer = L_3;
		int32_t L_4 = ___1_length;
		__this->____length = L_4;
		return;
	}
}
// Method Definition Index: 2388
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ReadOnlySpan_1__ctor_mA26404126E9D9DE6BE29D5F9EF6C6BC2422A2D88_inline (ReadOnlySpan_1_t2239736A651E959D4A4360EBC03DFBCFAE1C9DA6* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		goto IL_0016;
	}

IL_0016:
	{
		int32_t L_0 = ___1_length;
		if ((((int32_t)L_0) >= ((int32_t)0)))
		{
			goto IL_001f;
		}
	}
	{
		ThrowHelper_ThrowArgumentOutOfRangeException_mD7D90276EDCDF9394A8EA635923E3B48BB71BD56(NULL);
	}

IL_001f:
	{
		void* L_1 = ___0_pointer;
		TriggerBeginTarget_t5502949EBCED40452D61487C8D3CCB893F177576* L_2;
		L_2 = il2cpp_unsafe_as_ref<TriggerBeginTarget_t5502949EBCED40452D61487C8D3CCB893F177576>((uint8_t*)L_1);
		ByReference_1_tB78BE0105D10907AA8C665AF95DBAEF4BEF517CF L_3;
		memset((&L_3), 0, sizeof(L_3));
		il2cpp_codegen_by_reference_constructor((Il2CppByReference*)(&L_3), L_2);
		__this->____pointer = L_3;
		int32_t L_4 = ___1_length;
		__this->____length = L_4;
		return;
	}
}
// Method Definition Index: 2388
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ReadOnlySpan_1__ctor_m748A11CB59F4600404CFE970131654050E606631_inline (ReadOnlySpan_1_t4A1964D3768FECC83DDD199B546B177020E04377* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		goto IL_0016;
	}

IL_0016:
	{
		int32_t L_0 = ___1_length;
		if ((((int32_t)L_0) >= ((int32_t)0)))
		{
			goto IL_001f;
		}
	}
	{
		ThrowHelper_ThrowArgumentOutOfRangeException_mD7D90276EDCDF9394A8EA635923E3B48BB71BD56(NULL);
	}

IL_001f:
	{
		void* L_1 = ___0_pointer;
		TriggerEndTarget_t403C9C465F01F85B8C5E4BDDDE133CFF7EBD902A* L_2;
		L_2 = il2cpp_unsafe_as_ref<TriggerEndTarget_t403C9C465F01F85B8C5E4BDDDE133CFF7EBD902A>((uint8_t*)L_1);
		ByReference_1_t5A8D94A74D3EF9FFDEF739B5061D38830B7FE058 L_3;
		memset((&L_3), 0, sizeof(L_3));
		il2cpp_codegen_by_reference_constructor((Il2CppByReference*)(&L_3), L_2);
		__this->____pointer = L_3;
		int32_t L_4 = ___1_length;
		__this->____length = L_4;
		return;
	}
}
// Method Definition Index: 2481
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Span_1__ctor_m5599DAEC88C08C9797F461E977BF22E14E3C3008_fshared_inline (Span_1_tDEB40BEFA77B5E4BB49B058CD3050EEA4DD36C54* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) 
{
	CHECKED_LOCAL(classRgctxInit);
	CHECKED_LOCAL(Type_t_StaticInit);
	//<source_info:<no-source>:1>
	{
		bool L_0;
		L_0 = il2cpp_codegen_is_reference_or_contains_references(il2cpp_rgctx_method(CHECKED_LOCAL_INIT_PARAM(classRgctxInit,(il2cpp_codegen_method_rgctx(method)),il2cpp_codegen_initialized_method_rgctx,(method)), 4));
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(CHECKED_LOCAL_INIT_PARAM(classRgctxInit,(il2cpp_codegen_method_rgctx(method)),il2cpp_codegen_initialized_method_rgctx,(method)), 5)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		ThrowHelper_ThrowInvalidTypeWithPointersNotSupported_m5707DE408588F6EAC3FC7D10F9520308CF8C8CCF(L_2, NULL);
	}

IL_0016:
	{
		int32_t L_3 = ___1_length;
		if ((((int32_t)L_3) >= ((int32_t)0)))
		{
			goto IL_001f;
		}
	}
	{
		ThrowHelper_ThrowArgumentOutOfRangeException_mD7D90276EDCDF9394A8EA635923E3B48BB71BD56(NULL);
	}

IL_001f:
	{
		void* L_4 = ___0_pointer;
		Il2CppFullySharedGenericAny* L_5;
		L_5 = il2cpp_unsafe_as_ref<Il2CppFullySharedGenericAny>((uint8_t*)L_4);
		ByReference_1_t607C1F3BC28B0E21B969461CDB0720FB01A82141 L_6;
		memset((&L_6), 0, sizeof(L_6));
		il2cpp_codegen_by_reference_constructor((Il2CppByReference*)(&L_6), L_5);
		__this->____pointer = L_6;
		int32_t L_7 = ___1_length;
		__this->____length = L_7;
		return;
	}
}
// Method Definition Index: 2481
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Span_1__ctor_m8B358C367FCD4C5DF714C69892BD3F238BC4BE78_inline (Span_1_t9F6FBEA217E68146892F6B8BBCE2E2C9E95689A1* __this, void* ___0_pointer, int32_t ___1_length, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		goto IL_0016;
	}

IL_0016:
	{
		int32_t L_0 = ___1_length;
		if ((((int32_t)L_0) >= ((int32_t)0)))
		{
			goto IL_001f;
		}
	}
	{
		ThrowHelper_ThrowArgumentOutOfRangeException_mD7D90276EDCDF9394A8EA635923E3B48BB71BD56(NULL);
	}

IL_001f:
	{
		void* L_1 = ___0_pointer;
		TransformWriteTween_t86FB859350EF146AC5D9CB4CA8196377B714E2B7* L_2;
		L_2 = il2cpp_unsafe_as_ref<TransformWriteTween_t86FB859350EF146AC5D9CB4CA8196377B714E2B7>((uint8_t*)L_1);
		ByReference_1_tE65F7690AD68D042A57AB5586834E7F855D7028A L_3;
		memset((&L_3), 0, sizeof(L_3));
		il2cpp_codegen_by_reference_constructor((Il2CppByReference*)(&L_3), L_2);
		__this->____pointer = L_3;
		int32_t L_4 = ___1_length;
		__this->____length = L_4;
		return;
	}
}
// Method Definition Index: 41255
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool* UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mFAC64123CDCBD55D7F3EBE960A434127DBAC2DB0_inline (bool* ___0_from, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		bool* L_0 = ___0_from;
		bool* L_1;
		L_1 = UnsafeUtilityInternal_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mE3D9B5B2C16912294630A6DAD8928B960B7544E6_inline(L_0, NULL);
		return L_1;
	}
}
// Method Definition Index: 41255
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint8_t* UnsafeUtility_As_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m3DC6C8431AF46D3B4AD529D400BD9FD0DC961014_inline (uint8_t* ___0_from, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		uint8_t* L_0 = ___0_from;
		uint8_t* L_1;
		L_1 = UnsafeUtilityInternal_As_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m5A66C1A526E263EC6778FF3879A6E62C618542C4_inline(L_0, NULL);
		return L_1;
	}
}
// Method Definition Index: 41255
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int16_t* UnsafeUtility_As_TisInt16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_TisInt16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_m79136FE812DC030B796002F8D0127FADB3845447_inline (int16_t* ___0_from, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		int16_t* L_0 = ___0_from;
		int16_t* L_1;
		L_1 = UnsafeUtilityInternal_As_TisInt16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_TisInt16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_mD165D6F44825CD0E42C9C1F6248DB1E67976F9C2_inline(L_0, NULL);
		return L_1;
	}
}
// Method Definition Index: 70418
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void FlagStates_SetHasPosition_mE51FE437505C4A3EDDEAE595CDAE797026BF6A11_inline (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* __this, int32_t ___0_axis, bool ___1_changed, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B8_0 = NULL;
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B6_0 = NULL;
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B7_0 = NULL;
	int32_t G_B9_0 = 0;
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B9_1 = NULL;
	{
		int32_t L_0 = ___0_axis;
		switch (L_0)
		{
			case 0:
			{
				goto IL_0014;
			}
			case 1:
			{
				goto IL_001d;
			}
			case 2:
			{
				goto IL_0026;
			}
		}
	}
	{
		goto IL_002d;
	}

IL_0014:
	{
		bool L_1 = ___1_changed;
		__this->___HasPositionX = L_1;
		goto IL_002d;
	}

IL_001d:
	{
		bool L_2 = ___1_changed;
		__this->___HasPositionY = L_2;
		goto IL_002d;
	}

IL_0026:
	{
		bool L_3 = ___1_changed;
		__this->___HasPositionZ = L_3;
	}

IL_002d:
	{
		bool L_4 = __this->___HasPositionX;
		if (L_4)
		{
			G_B8_0 = __this;
			goto IL_0046;
		}
		G_B6_0 = __this;
	}
	{
		bool L_5 = __this->___HasPositionY;
		if (L_5)
		{
			G_B8_0 = G_B6_0;
			goto IL_0046;
		}
		G_B7_0 = G_B6_0;
	}
	{
		bool L_6 = __this->___HasPositionZ;
		G_B9_0 = ((int32_t)(L_6));
		G_B9_1 = G_B7_0;
		goto IL_0047;
	}

IL_0046:
	{
		G_B9_0 = 1;
		G_B9_1 = G_B8_0;
	}

IL_0047:
	{
		G_B9_1->___HasPositionChange = (bool)G_B9_0;
		return;
	}
}
// Method Definition Index: 70419
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void FlagStates_SetHasRotation_mD915333F46992653C0BB3B7B5795633C2FC44878_inline (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* __this, int32_t ___0_axis, bool ___1_changed, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B8_0 = NULL;
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B6_0 = NULL;
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B7_0 = NULL;
	int32_t G_B9_0 = 0;
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B9_1 = NULL;
	{
		int32_t L_0 = ___0_axis;
		switch (L_0)
		{
			case 0:
			{
				goto IL_0014;
			}
			case 1:
			{
				goto IL_001d;
			}
			case 2:
			{
				goto IL_0026;
			}
		}
	}
	{
		goto IL_002d;
	}

IL_0014:
	{
		bool L_1 = ___1_changed;
		__this->___HasRotAngleX = L_1;
		goto IL_002d;
	}

IL_001d:
	{
		bool L_2 = ___1_changed;
		__this->___HasRotAngleY = L_2;
		goto IL_002d;
	}

IL_0026:
	{
		bool L_3 = ___1_changed;
		__this->___HasRotAngleZ = L_3;
	}

IL_002d:
	{
		bool L_4 = __this->___HasRotAngleX;
		if (L_4)
		{
			G_B8_0 = __this;
			goto IL_0046;
		}
		G_B6_0 = __this;
	}
	{
		bool L_5 = __this->___HasRotAngleY;
		if (L_5)
		{
			G_B8_0 = G_B6_0;
			goto IL_0046;
		}
		G_B7_0 = G_B6_0;
	}
	{
		bool L_6 = __this->___HasRotAngleZ;
		G_B9_0 = ((int32_t)(L_6));
		G_B9_1 = G_B7_0;
		goto IL_0047;
	}

IL_0046:
	{
		G_B9_0 = 1;
		G_B9_1 = G_B8_0;
	}

IL_0047:
	{
		G_B9_1->___HasRotAngleChange = (bool)G_B9_0;
		return;
	}
}
// Method Definition Index: 70420
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void FlagStates_SetHasScale_m4CA0C4FA4015849D5D5EC76C831DF7EC08A023F3_inline (FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* __this, int32_t ___0_axis, bool ___1_changed, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B8_0 = NULL;
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B6_0 = NULL;
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B7_0 = NULL;
	int32_t G_B9_0 = 0;
	FlagStates_t262C67FDE9B9076C9470D392B29F04970E66149C* G_B9_1 = NULL;
	{
		int32_t L_0 = ___0_axis;
		switch (L_0)
		{
			case 0:
			{
				goto IL_0014;
			}
			case 1:
			{
				goto IL_001d;
			}
			case 2:
			{
				goto IL_0026;
			}
		}
	}
	{
		goto IL_002d;
	}

IL_0014:
	{
		bool L_1 = ___1_changed;
		__this->___HasScaleX = L_1;
		goto IL_002d;
	}

IL_001d:
	{
		bool L_2 = ___1_changed;
		__this->___HasScaleY = L_2;
		goto IL_002d;
	}

IL_0026:
	{
		bool L_3 = ___1_changed;
		__this->___HasScaleZ = L_3;
	}

IL_002d:
	{
		bool L_4 = __this->___HasScaleX;
		if (L_4)
		{
			G_B8_0 = __this;
			goto IL_0046;
		}
		G_B6_0 = __this;
	}
	{
		bool L_5 = __this->___HasScaleY;
		if (L_5)
		{
			G_B8_0 = G_B6_0;
			goto IL_0046;
		}
		G_B7_0 = G_B6_0;
	}
	{
		bool L_6 = __this->___HasScaleZ;
		G_B9_0 = ((int32_t)(L_6));
		G_B9_1 = G_B7_0;
		goto IL_0047;
	}

IL_0046:
	{
		G_B9_0 = 1;
		G_B9_1 = G_B8_0;
	}

IL_0047:
	{
		G_B9_1->___HasScaleChange = (bool)G_B9_0;
		return;
	}
}
// Method Definition Index: 43417
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Quaternion_get_Item_m0B886A8EF3417F3309FB0C681A67A4150B7AA739_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* __this, int32_t ___0_index, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		int32_t L_0 = ___0_index;
		switch (L_0)
		{
			case 0:
			{
				goto IL_0018;
			}
			case 1:
			{
				goto IL_001f;
			}
			case 2:
			{
				goto IL_0026;
			}
			case 3:
			{
				goto IL_002d;
			}
		}
	}
	{
		goto IL_0034;
	}

IL_0018:
	{
		float L_1 = __this->___x;
		return L_1;
	}

IL_001f:
	{
		float L_2 = __this->___y;
		return L_2;
	}

IL_0026:
	{
		float L_3 = __this->___z;
		return L_3;
	}

IL_002d:
	{
		float L_4 = __this->___w;
		return L_4;
	}

IL_0034:
	{
		IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82* L_5 = (IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82_il2cpp_TypeInfo_var)));
		IndexOutOfRangeException__ctor_mFD06819F05B815BE2D6E826D4E04F4C449D0A425(L_5, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral973C45718ACB19FB28D206360A3094F43D27EDED)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_5, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Quaternion_get_Item_m0B886A8EF3417F3309FB0C681A67A4150B7AA739_RuntimeMethod_var)));
	}
}
// Method Definition Index: 43472
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_Max_m870B77F6A5225EC21D9778043F987B9B17D08F6B_inline (SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* ___0_values, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	int32_t V_0 = 0;
	float V_1 = 0.0f;
	int32_t V_2 = 0;
	{
		SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* L_0 = ___0_values;
		NullCheck(L_0);
		int32_t L_1 = (il2cpp_codegen_conv<int32_t,int64_t,int64_t,false,false>((((RuntimeArray*)L_0)->max_length),NULL));
		V_0 = L_1;
		int32_t L_2 = V_0;
		if (L_2)
		{
			goto IL_000d;
		}
	}
	{
		return (0.0f);
	}

IL_000d:
	{
		SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* L_3 = ___0_values;
		NullCheck(L_3);
		int32_t L_4 = 0;
		float L_5 = (L_3)->GetAt(static_cast<il2cpp_array_size_t>(L_4));
		V_1 = L_5;
		V_2 = 1;
		goto IL_0023;
	}

IL_0015:
	{
		SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* L_6 = ___0_values;
		int32_t L_7 = V_2;
		NullCheck(L_6);
		int32_t L_8 = L_7;
		float L_9 = (L_6)->GetAt(static_cast<il2cpp_array_size_t>(L_8));
		float L_10 = V_1;
		if ((!(((float)L_9) > ((float)L_10))))
		{
			goto IL_001f;
		}
	}
	{
		SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* L_11 = ___0_values;
		int32_t L_12 = V_2;
		NullCheck(L_11);
		int32_t L_13 = L_12;
		float L_14 = (L_11)->GetAt(static_cast<il2cpp_array_size_t>(L_13));
		V_1 = L_14;
	}

IL_001f:
	{
		int32_t L_15 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_15, 1));
	}

IL_0023:
	{
		int32_t L_16 = V_2;
		int32_t L_17 = V_0;
		if ((((int32_t)L_16) < ((int32_t)L_17)))
		{
			goto IL_0015;
		}
	}
	{
		float L_18 = V_1;
		return L_18;
	}
}
// Method Definition Index: 43418
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Quaternion_set_Item_mFEF628DD58AC71A1E712A6F3F9642D5DA00675CE_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* __this, int32_t ___0_index, float ___1_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		int32_t L_0 = ___0_index;
		switch (L_0)
		{
			case 0:
			{
				goto IL_0018;
			}
			case 1:
			{
				goto IL_0020;
			}
			case 2:
			{
				goto IL_0028;
			}
			case 3:
			{
				goto IL_0030;
			}
		}
	}
	{
		goto IL_0038;
	}

IL_0018:
	{
		float L_1 = ___1_value;
		__this->___x = L_1;
		return;
	}

IL_0020:
	{
		float L_2 = ___1_value;
		__this->___y = L_2;
		return;
	}

IL_0028:
	{
		float L_3 = ___1_value;
		__this->___z = L_3;
		return;
	}

IL_0030:
	{
		float L_4 = ___1_value;
		__this->___w = L_4;
		return;
	}

IL_0038:
	{
		IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82* L_5 = (IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82_il2cpp_TypeInfo_var)));
		IndexOutOfRangeException__ctor_mFD06819F05B815BE2D6E826D4E04F4C449D0A425(L_5, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral973C45718ACB19FB28D206360A3094F43D27EDED)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_5, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Quaternion_set_Item_mFEF628DD58AC71A1E712A6F3F9642D5DA00675CE_RuntimeMethod_var)));
	}
}
// Method Definition Index: 96668
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 math_half_mF2B3098B2CDE13073D12FE17D4C55A7EF032C6C7_inline (float ___0_v, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		float L_0 = ___0_v;
		half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 L_1;
		memset((&L_1), 0, sizeof(L_1));
		half__ctor_m0A0FDAC33D58C3C0E0BB517078C2EAA71E0C30B1_inline((&L_1), L_0, NULL);
		return L_1;
	}
}
// Method Definition Index: 96671
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR half4_t04B1BC17C3559EC70A5CA2394C7C41B480EA83D8 math_half4_m377DDE973EE37D2127BA2577A2BCB56884A18E83_inline (half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___0_x, half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___1_y, half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___2_z, half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___3_w, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 L_0 = ___0_x;
		half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 L_1 = ___1_y;
		half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 L_2 = ___2_z;
		half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 L_3 = ___3_w;
		half4_t04B1BC17C3559EC70A5CA2394C7C41B480EA83D8 L_4;
		memset((&L_4), 0, sizeof(L_4));
		half4__ctor_m30972A6184726B0D0E0C1506DD656F8694369B54_inline((&L_4), L_0, L_1, L_2, L_3, NULL);
		return L_4;
	}
}
// Method Definition Index: 96966
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float4_t545A994996126766890C1F28B43EA823F2410190 float4_op_Implicit_mFC36DB25B838CA0D0D0BED5E4D89B1BE75F8212A_inline (half4_t04B1BC17C3559EC70A5CA2394C7C41B480EA83D8 ___0_v, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		half4_t04B1BC17C3559EC70A5CA2394C7C41B480EA83D8 L_0 = ___0_v;
		float4_t545A994996126766890C1F28B43EA823F2410190 L_1;
		memset((&L_1), 0, sizeof(L_1));
		float4__ctor_m33E515D88B7B4CBE94B4DAD00A8197C42E44A52D_inline((&L_1), L_0, NULL);
		return L_1;
	}
}
// Method Definition Index: 96820
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR quaternion_t9C8C2916B7359C174B215BBB41F290ABCBEA8AEA math_quaternion_mE62A8FC9087230BEA736EDFFF8E08B49A3E1BEC4_inline (float4_t545A994996126766890C1F28B43EA823F2410190 ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		float4_t545A994996126766890C1F28B43EA823F2410190 L_0 = ___0_value;
		quaternion_t9C8C2916B7359C174B215BBB41F290ABCBEA8AEA L_1;
		memset((&L_1), 0, sizeof(L_1));
		quaternion__ctor_m83A4AD6960040C90D6911B0F3AD54CE54DC5AF90_inline((&L_1), L_0, NULL);
		return L_1;
	}
}
// Method Definition Index: 43442
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_op_Implicit_m89F4373AD134797808033DCACE56E43E7829CF1E_inline (quaternion_t9C8C2916B7359C174B215BBB41F290ABCBEA8AEA ___0_q, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		quaternion_t9C8C2916B7359C174B215BBB41F290ABCBEA8AEA L_0 = ___0_q;
		float4_t545A994996126766890C1F28B43EA823F2410190 L_1 = L_0.___value;
		float L_2 = L_1.___x;
		quaternion_t9C8C2916B7359C174B215BBB41F290ABCBEA8AEA L_3 = ___0_q;
		float4_t545A994996126766890C1F28B43EA823F2410190 L_4 = L_3.___value;
		float L_5 = L_4.___y;
		quaternion_t9C8C2916B7359C174B215BBB41F290ABCBEA8AEA L_6 = ___0_q;
		float4_t545A994996126766890C1F28B43EA823F2410190 L_7 = L_6.___value;
		float L_8 = L_7.___z;
		quaternion_t9C8C2916B7359C174B215BBB41F290ABCBEA8AEA L_9 = ___0_q;
		float4_t545A994996126766890C1F28B43EA823F2410190 L_10 = L_9.___value;
		float L_11 = L_10.___w;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_12;
		memset((&L_12), 0, sizeof(L_12));
		Quaternion__ctor_m868FD60AA65DD5A8AC0C5DEB0608381A8D85FCD8_inline((&L_12), L_2, L_5, L_8, L_11, NULL);
		return L_12;
	}
}
// Method Definition Index: 43373
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_zero_m0C1249C3F25B1C70EAD3CC8B31259975A457AE39_inline (const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ((Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_StaticFields*)il2cpp_codegen_static_fields_for(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var))->___zeroVector;
		return L_0;
	}
}
// Method Definition Index: 96646
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float3_t7600B73F092B37F484B12910A5269F30C778D31E math_float3_mBC35F669739DF837407D396F2219211EC69F513A_inline (half3_tAC3065568DE0CD35A46DE11D367236E8FB7BEA07 ___0_v, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		half3_tAC3065568DE0CD35A46DE11D367236E8FB7BEA07 L_0 = ___0_v;
		float3_t7600B73F092B37F484B12910A5269F30C778D31E L_1;
		memset((&L_1), 0, sizeof(L_1));
		float3__ctor_mF5C4C7146A9B4CBA037E080878C7D0EC10007700_inline((&L_1), L_0, NULL);
		return L_1;
	}
}
// Method Definition Index: 43392
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Implicit_m67D7F2AD018B7F0B44E10CF164D63A4FB32E6B7D_inline (float3_t7600B73F092B37F484B12910A5269F30C778D31E ___0_v, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		float3_t7600B73F092B37F484B12910A5269F30C778D31E L_0 = ___0_v;
		float L_1 = L_0.___x;
		float3_t7600B73F092B37F484B12910A5269F30C778D31E L_2 = ___0_v;
		float L_3 = L_2.___y;
		float3_t7600B73F092B37F484B12910A5269F30C778D31E L_4 = ___0_v;
		float L_5 = L_4.___z;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6;
		memset((&L_6), 0, sizeof(L_6));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_6), L_1, L_3, L_5, NULL);
		return L_6;
	}
}
// Method Definition Index: 43345
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector3_set_Item_m79136861DEC5862CE7EC20AB3B0EF10A3957CEC3_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, int32_t ___0_index, float ___1_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		int32_t L_0 = ___0_index;
		switch (L_0)
		{
			case 0:
			{
				goto IL_0014;
			}
			case 1:
			{
				goto IL_001c;
			}
			case 2:
			{
				goto IL_0024;
			}
		}
	}
	{
		goto IL_002c;
	}

IL_0014:
	{
		float L_1 = ___1_value;
		__this->___x = L_1;
		return;
	}

IL_001c:
	{
		float L_2 = ___1_value;
		__this->___y = L_2;
		return;
	}

IL_0024:
	{
		float L_3 = ___1_value;
		__this->___z = L_3;
		return;
	}

IL_002c:
	{
		IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82* L_4 = (IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82_il2cpp_TypeInfo_var)));
		IndexOutOfRangeException__ctor_mFD06819F05B815BE2D6E826D4E04F4C449D0A425(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral27C7727EAAAD675C621F6257F2BD5190CE343979)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector3_set_Item_m79136861DEC5862CE7EC20AB3B0EF10A3957CEC3_RuntimeMethod_var)));
	}
}
// Method Definition Index: 8200
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool GCHandle_get_IsAllocated_m241908103D8D867E11CCAB73C918729825E86843_inline (GCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC* __this, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		intptr_t L_0 = __this->___handle;
		bool L_1;
		L_1 = IntPtr_op_Inequality_m90EFC9C4CAD9A33E309F2DDF98EE4E1DD253637B_inline(L_0, 0, NULL);
		return L_1;
	}
}
// Method Definition Index: 8203
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool GCHandle_CanDereferenceHandle_mAAAC42D1268CEF3FDD040A3D1574773D08140579_inline (intptr_t ___0_handle, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		intptr_t L_0 = ___0_handle;
		intptr_t L_1 = (il2cpp_codegen_conv<intptr_t,int32_t,int32_t,false,false>(1,NULL));
		intptr_t L_2 = (il2cpp_codegen_conv<intptr_t,int32_t,int32_t,false,false>(0,NULL));
		return (bool)((((intptr_t)((intptr_t)(L_0&L_1))) == ((intptr_t)L_2))? 1 : 0);
	}
}
// Method Definition Index: 8201
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* GCHandle_GetRef_mAC7E58E62417209DC41C99F66BA70F0C3AA18DA8_inline (intptr_t ___0_handle, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		intptr_t L_0 = ___0_handle;
		void* L_1;
		L_1 = IntPtr_op_Explicit_m2728CBA081E79B97DDCF1D4FAD77B309CA1E94BF(L_0, NULL);
		RuntimeObject** L_2;
		L_2 = il2cpp_unsafe_as_ref<RuntimeObject*>((intptr_t*)L_1);
		RuntimeObject* L_3 = *(L_2);
		return L_3;
	}
}
// Method Definition Index: 41255
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR GCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC* UnsafeUtility_As_TisIntPtr_t_TisGCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC_mD94F597CB91662C823496DA9FA9A7CF908734A78_inline (intptr_t* ___0_from, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		intptr_t* L_0 = ___0_from;
		GCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC* L_1;
		L_1 = UnsafeUtilityInternal_As_TisIntPtr_t_TisGCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC_mD43127D5F7AA6EB4B52E5C30BA53F29843E9E9A2_inline(L_0, NULL);
		return L_1;
	}
}
// Method Definition Index: 99131
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Il2CppFullySharedGenericAny* UnsafeUtilityInternal_As_TisIl2CppFullySharedGenericAny_TisIl2CppFullySharedGenericAny_mE1CA751887466B801BE69083C2B0EA3EDE41FF9B_fshared_inline (Il2CppFullySharedGenericAny* ___0_from, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		Il2CppFullySharedGenericAny* L_0 = ___0_from;
		return (Il2CppFullySharedGenericAny*)(L_0);
	}
}
// Method Definition Index: 97013
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void half__ctor_m0A0FDAC33D58C3C0E0BB517078C2EAA71E0C30B1_inline (half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579* __this, float ___0_v, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		float L_0 = ___0_v;
		uint32_t L_1;
		L_1 = math_f32tof16_mE56D11292C9F7B0C4A14A77AB907C3EC7D571251_inline(L_0, NULL);
		uint16_t L_2 = (il2cpp_codegen_conv<uint16_t,uint32_t,int32_t,false,false>(L_1,NULL));
		__this->___value = L_2;
		return;
	}
}
// Method Definition Index: 97030
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void half4__ctor_m30972A6184726B0D0E0C1506DD656F8694369B54_inline (half4_t04B1BC17C3559EC70A5CA2394C7C41B480EA83D8* __this, half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___0_x, half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___1_y, half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___2_z, half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___3_w, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 L_0 = ___0_x;
		__this->___x = L_0;
		half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 L_1 = ___1_y;
		__this->___y = L_1;
		half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 L_2 = ___2_z;
		__this->___z = L_2;
		half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 L_3 = ___3_w;
		__this->___w = L_3;
		return;
	}
}
// Method Definition Index: 96963
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void float4__ctor_m33E515D88B7B4CBE94B4DAD00A8197C42E44A52D_inline (float4_t545A994996126766890C1F28B43EA823F2410190* __this, half4_t04B1BC17C3559EC70A5CA2394C7C41B480EA83D8 ___0_v, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		half4_t04B1BC17C3559EC70A5CA2394C7C41B480EA83D8 L_0 = ___0_v;
		half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 L_1 = L_0.___x;
		float L_2;
		L_2 = half_op_Implicit_m612FDBFDC8E65B79692FC9C0EFE65583E55C6F60_inline(L_1, NULL);
		__this->___x = L_2;
		half4_t04B1BC17C3559EC70A5CA2394C7C41B480EA83D8 L_3 = ___0_v;
		half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 L_4 = L_3.___y;
		float L_5;
		L_5 = half_op_Implicit_m612FDBFDC8E65B79692FC9C0EFE65583E55C6F60_inline(L_4, NULL);
		__this->___y = L_5;
		half4_t04B1BC17C3559EC70A5CA2394C7C41B480EA83D8 L_6 = ___0_v;
		half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 L_7 = L_6.___z;
		float L_8;
		L_8 = half_op_Implicit_m612FDBFDC8E65B79692FC9C0EFE65583E55C6F60_inline(L_7, NULL);
		__this->___z = L_8;
		half4_t04B1BC17C3559EC70A5CA2394C7C41B480EA83D8 L_9 = ___0_v;
		half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 L_10 = L_9.___w;
		float L_11;
		L_11 = half_op_Implicit_m612FDBFDC8E65B79692FC9C0EFE65583E55C6F60_inline(L_10, NULL);
		__this->___w = L_11;
		return;
	}
}
// Method Definition Index: 97076
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void quaternion__ctor_m83A4AD6960040C90D6911B0F3AD54CE54DC5AF90_inline (quaternion_t9C8C2916B7359C174B215BBB41F290ABCBEA8AEA* __this, float4_t545A994996126766890C1F28B43EA823F2410190 ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		float4_t545A994996126766890C1F28B43EA823F2410190 L_0 = ___0_value;
		__this->___value = L_0;
		return;
	}
}
// Method Definition Index: 43419
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Quaternion__ctor_m868FD60AA65DD5A8AC0C5DEB0608381A8D85FCD8_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* __this, float ___0_x, float ___1_y, float ___2_z, float ___3_w, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		float L_0 = ___0_x;
		__this->___x = L_0;
		float L_1 = ___1_y;
		__this->___y = L_1;
		float L_2 = ___2_z;
		__this->___z = L_2;
		float L_3 = ___3_w;
		__this->___w = L_3;
		return;
	}
}
// Method Definition Index: 96905
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void float3__ctor_mF5C4C7146A9B4CBA037E080878C7D0EC10007700_inline (float3_t7600B73F092B37F484B12910A5269F30C778D31E* __this, half3_tAC3065568DE0CD35A46DE11D367236E8FB7BEA07 ___0_v, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		half3_tAC3065568DE0CD35A46DE11D367236E8FB7BEA07 L_0 = ___0_v;
		half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 L_1 = L_0.___x;
		float L_2;
		L_2 = half_op_Implicit_m612FDBFDC8E65B79692FC9C0EFE65583E55C6F60_inline(L_1, NULL);
		__this->___x = L_2;
		half3_tAC3065568DE0CD35A46DE11D367236E8FB7BEA07 L_3 = ___0_v;
		half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 L_4 = L_3.___y;
		float L_5;
		L_5 = half_op_Implicit_m612FDBFDC8E65B79692FC9C0EFE65583E55C6F60_inline(L_4, NULL);
		__this->___y = L_5;
		half3_tAC3065568DE0CD35A46DE11D367236E8FB7BEA07 L_6 = ___0_v;
		half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 L_7 = L_6.___z;
		float L_8;
		L_8 = half_op_Implicit_m612FDBFDC8E65B79692FC9C0EFE65583E55C6F60_inline(L_7, NULL);
		__this->___z = L_8;
		return;
	}
}
// Method Definition Index: 43346
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, float ___0_x, float ___1_y, float ___2_z, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		float L_0 = ___0_x;
		__this->___x = L_0;
		float L_1 = ___1_y;
		__this->___y = L_1;
		float L_2 = ___2_z;
		__this->___z = L_2;
		return;
	}
}
// Method Definition Index: 3924
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool IntPtr_op_Inequality_m90EFC9C4CAD9A33E309F2DDF98EE4E1DD253637B_inline (intptr_t ___0_value1, intptr_t ___1_value2, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		intptr_t L_0 = ___0_value1;
		intptr_t L_1 = ___1_value2;
		return (bool)((((int32_t)((((intptr_t)L_0) == ((intptr_t)L_1))? 1 : 0)) == ((int32_t)0))? 1 : 0);
	}
}
// Method Definition Index: 96805
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint32_t math_f32tof16_mE56D11292C9F7B0C4A14A77AB907C3EC7D571251_inline (float ___0_x, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	uint32_t V_0 = 0;
	uint32_t V_1 = 0;
	{
		float L_0 = ___0_x;
		uint32_t L_1;
		L_1 = math_asuint_mF26E6B0D25FD1C079FB93E913E339218F2D3B971_inline(L_0, NULL);
		V_0 = L_1;
		uint32_t L_2 = V_0;
		V_1 = ((int32_t)((int32_t)L_2&((int32_t)2147479552)));
		uint32_t L_3 = V_1;
		float L_4;
		L_4 = math_asfloat_mE332F9C6D56AA099930259ECE729FC5EC8FD2ED8_inline(L_3, NULL);
		float L_5;
		L_5 = math_min_m6AF1FAD0C7D0231E06EB29D9CDB7B19AB11E7C21_inline(((float)il2cpp_codegen_multiply(L_4, (1.92592994E-34f))), (260042752.0f), NULL);
		uint32_t L_6;
		L_6 = math_asuint_mF26E6B0D25FD1C079FB93E913E339218F2D3B971_inline(L_5, NULL);
		uint32_t L_7 = V_1;
		uint32_t L_8;
		L_8 = math_select_mED0B241C12084CE6A281C094820E7FCF0233448C_inline(((int32_t)31744), ((int32_t)32256), (bool)((((int32_t)L_7) > ((int32_t)((int32_t)2139095040)))? 1 : 0), NULL);
		uint32_t L_9 = V_1;
		uint32_t L_10;
		L_10 = math_select_mED0B241C12084CE6A281C094820E7FCF0233448C_inline(((int32_t)((uint32_t)((int32_t)il2cpp_codegen_add((int32_t)L_6, ((int32_t)4096)))>>((int32_t)13))), L_8, (bool)((((int32_t)((((int32_t)L_9) < ((int32_t)((int32_t)2139095040)))? 1 : 0)) == ((int32_t)0))? 1 : 0), NULL);
		uint32_t L_11 = V_0;
		return ((int32_t)((int32_t)L_10|((int32_t)((uint32_t)((int32_t)((int32_t)L_11&((int32_t)-2147479553)))>>((int32_t)16)))));
	}
}
// Method Definition Index: 97015
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float half_op_Implicit_m612FDBFDC8E65B79692FC9C0EFE65583E55C6F60_inline (half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 ___0_d, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		half_t8CDA1C7C4BBA15C1B8F35F4DC750E1E491691579 L_0 = ___0_d;
		uint16_t L_1 = L_0.___value;
		float L_2;
		L_2 = math_f16tof32_m3893A7053FE430E3216E25A97E9E9CFF5ABF650D_inline(L_1, NULL);
		return L_2;
	}
}
// Method Definition Index: 96681
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint32_t math_asuint_mF26E6B0D25FD1C079FB93E913E339218F2D3B971_inline (float ___0_x, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		uintptr_t L_0 = (il2cpp_codegen_conv<uintptr_t,float*,intptr_t,false,false>((&___0_x),NULL));
		int32_t L_1 = ((int32_t)*(((uint32_t*)L_0)));
		return L_1;
	}
}
// Method Definition Index: 96686
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float math_asfloat_mE332F9C6D56AA099930259ECE729FC5EC8FD2ED8_inline (uint32_t ___0_x, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		uintptr_t L_0 = (il2cpp_codegen_conv<uintptr_t,uint32_t*,intptr_t,false,false>((&___0_x),NULL));
		float L_1 = *(((float*)L_0));
		return L_1;
	}
}
// Method Definition Index: 96696
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float math_min_m6AF1FAD0C7D0231E06EB29D9CDB7B19AB11E7C21_inline (float ___0_x, float ___1_y, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		float L_0 = ___1_y;
		bool L_1;
		L_1 = Single_IsNaN_mFE637F6ECA9F7697CE8EFF56427858F4C5EDF75D_inline(L_0, NULL);
		if (L_1)
		{
			goto IL_000e;
		}
	}
	{
		float L_2 = ___0_x;
		float L_3 = ___1_y;
		if ((((float)L_2) < ((float)L_3)))
		{
			goto IL_000e;
		}
	}
	{
		float L_4 = ___1_y;
		return L_4;
	}

IL_000e:
	{
		float L_5 = ___0_x;
		return L_5;
	}
}
// Method Definition Index: 96774
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint32_t math_select_mED0B241C12084CE6A281C094820E7FCF0233448C_inline (uint32_t ___0_falseValue, uint32_t ___1_trueValue, bool ___2_test, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		bool L_0 = ___2_test;
		if (L_0)
		{
			goto IL_0005;
		}
	}
	{
		uint32_t L_1 = ___0_falseValue;
		return L_1;
	}

IL_0005:
	{
		uint32_t L_2 = ___1_trueValue;
		return L_2;
	}
}
// Method Definition Index: 96804
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float math_f16tof32_m3893A7053FE430E3216E25A97E9E9CFF5ABF650D_inline (uint32_t ___0_x, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	uint32_t V_0 = 0;
	{
		uint32_t L_0 = ___0_x;
		int32_t L_1 = ((int32_t)(((int32_t)((int32_t)L_0&((int32_t)32767)))<<((int32_t)13)));
		V_0 = ((int32_t)(L_1&((int32_t)260046848)));
		uint32_t L_2 = V_0;
		uint32_t L_3;
		L_3 = math_select_mED0B241C12084CE6A281C094820E7FCF0233448C_inline(0, ((int32_t)939524096), (bool)((((int32_t)L_2) == ((int32_t)((int32_t)260046848)))? 1 : 0), NULL);
		int32_t L_4 = ((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_1, ((int32_t)939524096))), (int32_t)L_3));
		float L_5;
		L_5 = math_asfloat_mE332F9C6D56AA099930259ECE729FC5EC8FD2ED8_inline(((int32_t)il2cpp_codegen_add(L_4, ((int32_t)8388608))), NULL);
		uint32_t L_6;
		L_6 = math_asuint_mF26E6B0D25FD1C079FB93E913E339218F2D3B971_inline(((float)il2cpp_codegen_subtract(L_5, (6.10351562E-05f))), NULL);
		uint32_t L_7 = V_0;
		uint32_t L_8;
		L_8 = math_select_mED0B241C12084CE6A281C094820E7FCF0233448C_inline(L_4, L_6, (bool)((((int32_t)L_7) == ((int32_t)0))? 1 : 0), NULL);
		uint32_t L_9 = ___0_x;
		float L_10;
		L_10 = math_asfloat_mE332F9C6D56AA099930259ECE729FC5EC8FD2ED8_inline(((int32_t)((int32_t)L_8|((int32_t)(((int32_t)((int32_t)L_9&((int32_t)32768)))<<((int32_t)16))))), NULL);
		return L_10;
	}
}
// Method Definition Index: 2444
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Single_IsNaN_mFE637F6ECA9F7697CE8EFF56427858F4C5EDF75D_inline (float ___0_f, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		float L_0 = ___0_f;
		int32_t L_1;
		L_1 = BitConverter_SingleToInt32Bits_mC760C7CFC89725E3CF68DC45BE3A9A42A7E7DA73_inline(L_0, NULL);
		return (bool)((((int32_t)((int32_t)(L_1&((int32_t)2147483647LL)))) > ((int32_t)((int32_t)2139095040)))? 1 : 0);
	}
}
// Method Definition Index: 1053
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t BitConverter_SingleToInt32Bits_mC760C7CFC89725E3CF68DC45BE3A9A42A7E7DA73_inline (float ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		uintptr_t L_0 = (il2cpp_codegen_conv<uintptr_t,float*,intptr_t,false,false>((&___0_value),NULL));
		int32_t L_1 = *(((int32_t*)L_0));
		return L_1;
	}
}
