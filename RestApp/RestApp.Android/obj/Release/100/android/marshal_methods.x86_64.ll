; ModuleID = 'obj\Release\100\android\marshal_methods.x86_64.ll'
source_filename = "obj\Release\100\android\marshal_methods.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 8
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [100 x i64] [
	i64 120698629574877762, ; 0: Mono.Android => 0x1accec39cafe242 => 3
	i64 156291772854606065, ; 1: I18N.West => 0x22b428a125098f1 => 36
	i64 232391251801502327, ; 2: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 40
	i64 263803244706540312, ; 3: Rg.Plugins.Popup.dll => 0x3a937a743542b18 => 38
	i64 702024105029695270, ; 4: System.Drawing.Common => 0x9be17343c0e7726 => 27
	i64 720058930071658100, ; 5: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 17
	i64 872800313462103108, ; 6: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 15
	i64 940822596282819491, ; 7: System.Transactions => 0xd0e792aa81923a3 => 29
	i64 996343623809489702, ; 8: Xamarin.Forms.Platform => 0xdd3b93f3b63db26 => 45
	i64 1000557547492888992, ; 9: Mono.Security.dll => 0xde2b1c9cba651a0 => 30
	i64 1120440138749646132, ; 10: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 25
	i64 1425944114962822056, ; 11: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 1
	i64 1493452499941003209, ; 12: I18N.CJK => 0x14b9cf22d3e70fc9 => 32
	i64 1624659445732251991, ; 13: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 9
	i64 1795316252682057001, ; 14: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 10
	i64 1836611346387731153, ; 15: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 40
	i64 1981742497975770890, ; 16: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 20
	i64 2262844636196693701, ; 17: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 15
	i64 2329709569556905518, ; 18: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 19
	i64 2470498323731680442, ; 19: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 12
	i64 2547086958574651984, ; 20: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 39
	i64 2592350477072141967, ; 21: System.Xml.dll => 0x23f9e10627330e8f => 8
	i64 2624866290265602282, ; 22: mscorlib.dll => 0x246d65fbde2db8ea => 4
	i64 2960931600190307745, ; 23: Xamarin.Forms.Core => 0x2917579a49927da1 => 42
	i64 3017704767998173186, ; 24: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 25
	i64 3289520064315143713, ; 25: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 18
	i64 3522470458906976663, ; 26: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 23
	i64 3531994851595924923, ; 27: System.Numerics => 0x31042a9aade235bb => 7
	i64 3572576518857361216, ; 28: I18N => 0x3194576a63650740 => 31
	i64 3727469159507183293, ; 29: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 22
	i64 4525561845656915374, ; 30: System.ServiceModel.Internals => 0x3ece06856b710dae => 26
	i64 4794310189461587505, ; 31: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 39
	i64 4795410492532947900, ; 32: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 23
	i64 5142919913060024034, ; 33: Xamarin.Forms.Platform.Android.dll => 0x475f52699e39bee2 => 44
	i64 5203618020066742981, ; 34: Xamarin.Essentials => 0x4836f704f0e652c5 => 41
	i64 5375264076663995773, ; 35: Xamarin.Forms.PancakeView => 0x4a98c632c779bd7d => 43
	i64 5398069113008343190, ; 36: I18N.West.dll => 0x4ae9cb4211dec896 => 36
	i64 5507995362134886206, ; 37: System.Core.dll => 0x4c705499688c873e => 5
	i64 5878178646025157113, ; 38: I18N.Other => 0x51937c55aa9db9f9 => 34
	i64 6085203216496545422, ; 39: Xamarin.Forms.Platform.dll => 0x5472fc15a9574e8e => 45
	i64 6086316965293125504, ; 40: FormsViewGroup.dll => 0x5476f10882baef80 => 37
	i64 6401687960814735282, ; 41: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 19
	i64 6548213210057960872, ; 42: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 14
	i64 6659513131007730089, ; 43: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 17
	i64 6859762521039231502, ; 44: RestApp.dll => 0x5f32c5ab1614da0e => 49
	i64 7635363394907363464, ; 45: Xamarin.Forms.Core.dll => 0x69f6428dc4795888 => 42
	i64 7637365915383206639, ; 46: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 41
	i64 7654504624184590948, ; 47: System.Net.Http => 0x6a3a4366801b8264 => 0
	i64 7747785289863678794, ; 48: I18N.Rare => 0x6b85a9abee524b4a => 35
	i64 7820441508502274321, ; 49: System.Data => 0x6c87ca1e14ff8111 => 28
	i64 7836164640616011524, ; 50: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 9
	i64 7867610841234767674, ; 51: I18N.Rare.dll => 0x6d2f5e602ecf7f3a => 35
	i64 8083354569033831015, ; 52: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 18
	i64 8167236081217502503, ; 53: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 2
	i64 8265650852517415196, ; 54: I18N.dll => 0x72b57da835b4891c => 31
	i64 8618070908946355220, ; 55: I18N.MidEast => 0x779989d4c8e01414 => 33
	i64 8626175481042262068, ; 56: Java.Interop => 0x77b654e585b55834 => 2
	i64 9324707631942237306, ; 57: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 10
	i64 9662334977499516867, ; 58: System.Numerics.dll => 0x8617827802b0cfc3 => 7
	i64 9678050649315576968, ; 59: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 12
	i64 9808709177481450983, ; 60: Mono.Android.dll => 0x881f890734e555e7 => 3
	i64 9834056768316610435, ; 61: System.Transactions.dll => 0x8879968718899783 => 29
	i64 9998632235833408227, ; 62: Mono.Security => 0x8ac2470b209ebae3 => 30
	i64 10038780035334861115, ; 63: System.Net.Http.dll => 0x8b50e941206af13b => 0
	i64 10229024438826829339, ; 64: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 14
	i64 10430153318873392755, ; 65: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 13
	i64 10841941198020570030, ; 66: I18N.MidEast.dll => 0x9676501397b06bae => 33
	i64 11023048688141570732, ; 67: System.Core => 0x98f9bc61168392ac => 5
	i64 11037814507248023548, ; 68: System.Xml => 0x992e31d0412bf7fc => 8
	i64 11162124722117608902, ; 69: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 24
	i64 11529969570048099689, ; 70: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 24
	i64 12451044538927396471, ; 71: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 16
	i64 12466513435562512481, ; 72: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 21
	i64 12538491095302438457, ; 73: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 11
	i64 12685362927807838697, ; 74: RestApp.Android => 0xb00b765f76e539e9 => 48
	i64 12963446364377008305, ; 75: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 27
	i64 12986822521348711275, ; 76: I18N.Other.dll => 0xb43a7646aa08636b => 34
	i64 13370592475155966277, ; 77: System.Runtime.Serialization => 0xb98de304062ea945 => 1
	i64 13454009404024712428, ; 78: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 47
	i64 13572454107664307259, ; 79: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 22
	i64 13647894001087880694, ; 80: System.Data.dll => 0xbd670f48cb071df6 => 28
	i64 13959074834287824816, ; 81: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 16
	i64 13967638549803255703, ; 82: Xamarin.Forms.Platform.Android => 0xc1d70541e0134797 => 44
	i64 14124974489674258913, ; 83: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 11
	i64 14423771765264968721, ; 84: RestApp => 0xc82b880005ed6c11 => 49
	i64 14792063746108907174, ; 85: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 47
	i64 14974895996694813091, ; 86: RestApp.Android.dll => 0xcfd184918f69d9a3 => 48
	i64 15370334346939861994, ; 87: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 13
	i64 15609085926864131306, ; 88: System.dll => 0xd89e9cf3334914ea => 6
	i64 15728157151893626066, ; 89: I18N.CJK.dll => 0xda45a3992a239cd2 => 32
	i64 15810740023422282496, ; 90: Xamarin.Forms.Xaml => 0xdb6b08484c22eb00 => 46
	i64 16154507427712707110, ; 91: System => 0xe03056ea4e39aa26 => 6
	i64 16833383113903931215, ; 92: mscorlib => 0xe99c30c1484d7f4f => 4
	i64 17285063141349522879, ; 93: Rg.Plugins.Popup => 0xefe0e158cc55fdbf => 38
	i64 17704177640604968747, ; 94: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 21
	i64 17710060891934109755, ; 95: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 20
	i64 17827832363535584534, ; 96: Xamarin.Forms.PancakeView.dll => 0xf7692f1427c04d16 => 43
	i64 17882897186074144999, ; 97: FormsViewGroup => 0xf82cd03e3ac830e7 => 37
	i64 17892495832318972303, ; 98: Xamarin.Forms.Xaml.dll => 0xf84eea293687918f => 46
	i64 18129453464017766560 ; 99: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 26
], align 16
@assembly_image_cache_indices = local_unnamed_addr constant [100 x i32] [
	i32 3, i32 36, i32 40, i32 38, i32 27, i32 17, i32 15, i32 29, ; 0..7
	i32 45, i32 30, i32 25, i32 1, i32 32, i32 9, i32 10, i32 40, ; 8..15
	i32 20, i32 15, i32 19, i32 12, i32 39, i32 8, i32 4, i32 42, ; 16..23
	i32 25, i32 18, i32 23, i32 7, i32 31, i32 22, i32 26, i32 39, ; 24..31
	i32 23, i32 44, i32 41, i32 43, i32 36, i32 5, i32 34, i32 45, ; 32..39
	i32 37, i32 19, i32 14, i32 17, i32 49, i32 42, i32 41, i32 0, ; 40..47
	i32 35, i32 28, i32 9, i32 35, i32 18, i32 2, i32 31, i32 33, ; 48..55
	i32 2, i32 10, i32 7, i32 12, i32 3, i32 29, i32 30, i32 0, ; 56..63
	i32 14, i32 13, i32 33, i32 5, i32 8, i32 24, i32 24, i32 16, ; 64..71
	i32 21, i32 11, i32 48, i32 27, i32 34, i32 1, i32 47, i32 22, ; 72..79
	i32 28, i32 16, i32 44, i32 11, i32 49, i32 47, i32 48, i32 13, ; 80..87
	i32 6, i32 32, i32 46, i32 6, i32 4, i32 38, i32 21, i32 20, ; 88..95
	i32 43, i32 37, i32 46, i32 26 ; 96..99
], align 16

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 8; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 8

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 8
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 8
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 16; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1}
!llvm.ident = !{!2}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
