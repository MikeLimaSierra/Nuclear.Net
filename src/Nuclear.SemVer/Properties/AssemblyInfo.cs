﻿using System.Runtime.CompilerServices;

#if RELEASE
[assembly: InternalsVisibleTo("Nuclear.SemVer.uTests, PublicKey=002400000e800000140200000602000000240000525341310010000001000100c924c5dbe9b637c6c106b54300d8bb6c6199f64012f0629e9992dc6873f2a221f2c42a60984e051287c5f6884926541564581ad2b1ee1f0a826ffbd4dc02f84238afc0fd21c0bd8b7bbfcac6accebf11db375f7b7ac3871fa602ac1e00f31288b7244cb61e84921715019c06bedb09ca0e3f5f3733cf68303c9f682d1818a0b3a96dcf78f16eff31d81bf910086acdd0c7991c81fa9645130b40a6b86d8e720f11f3622b4880568cf39beb9950837073fa40984bbb95ec7de842dc6e3d5101462d907f35061cc47c2c2b2c300b170f7fd0253c59d08351a2aff1ca262423f4844e7fd4ff53c7f7224427acccebf2b4df589e178b0774aaf1db44a57e28b6667fa3546438a3fa64f760e06b31190f28a3cb24d4ce58c4954c87cf25402db7a0c1c50f26ae30be9fa63cd47b742d208b51c11208b0ef8663d279f46a19432fc11580d2fadd485e1fc52cd86df0f6a7efb579fc7205197ec65fb905030459701e711723c69eff47a7353e16e4c925f7099cd5cb6dcd9bb9b35deea5bb0bbf23ceefb5837fdbf0cc92bb98c79347181fe4bfd721666257fd75f50421d6b483a456185a90b43c984ec8b511eac1e70e28209924cd25ce2f667e3dfc50f9910ae760ed4d4214aa16060d749a85fb08373a0c6c7d6e710e45384d161cc47e05be13120810fcbb445bcc5650142cd166fd984c7ee5fadddef396cfab4986731ddf6b27ec")]
#elif INTEGRATION
[assembly: InternalsVisibleTo("Nuclear.SemVer.uTests, PublicKey=002400000e800000140200000602000000240000525341310010000001000100c924c5dbe9b637c6c106b54300d8bb6c6199f64012f0629e9992dc6873f2a221f2c42a60984e051287c5f6884926541564581ad2b1ee1f0a826ffbd4dc02f84238afc0fd21c0bd8b7bbfcac6accebf11db375f7b7ac3871fa602ac1e00f31288b7244cb61e84921715019c06bedb09ca0e3f5f3733cf68303c9f682d1818a0b3a96dcf78f16eff31d81bf910086acdd0c7991c81fa9645130b40a6b86d8e720f11f3622b4880568cf39beb9950837073fa40984bbb95ec7de842dc6e3d5101462d907f35061cc47c2c2b2c300b170f7fd0253c59d08351a2aff1ca262423f4844e7fd4ff53c7f7224427acccebf2b4df589e178b0774aaf1db44a57e28b6667fa3546438a3fa64f760e06b31190f28a3cb24d4ce58c4954c87cf25402db7a0c1c50f26ae30be9fa63cd47b742d208b51c11208b0ef8663d279f46a19432fc11580d2fadd485e1fc52cd86df0f6a7efb579fc7205197ec65fb905030459701e711723c69eff47a7353e16e4c925f7099cd5cb6dcd9bb9b35deea5bb0bbf23ceefb5837fdbf0cc92bb98c79347181fe4bfd721666257fd75f50421d6b483a456185a90b43c984ec8b511eac1e70e28209924cd25ce2f667e3dfc50f9910ae760ed4d4214aa16060d749a85fb08373a0c6c7d6e710e45384d161cc47e05be13120810fcbb445bcc5650142cd166fd984c7ee5fadddef396cfab4986731ddf6b27ec")]
#else
[assembly: InternalsVisibleTo("Nuclear.SemVer.uTests")]
#endif