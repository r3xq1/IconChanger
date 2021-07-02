namespace IconChanger
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    [SuppressUnmanagedCodeSecurity()]
    internal static class NativeMethods
    {
        [DllImport("kernel32")]
        public static extern bool UpdateResource(IntPtr hUpdate, IntPtr type, IntPtr name, short language,
        [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] data, int dataSize);


        /// <summary>
        /// Returns a handle to either a language-neutral portable executable file (LN file) or a 
        /// language-specific resource file (.mui file) that can be used by the UpdateResource function 
        /// to add, delete, or replace resources in a binary module.
        /// </summary>
        /// <param name="pFileName">Pointer to a null-terminated string that specifies the binary file in which to update resources.</param>
        /// <param name="bDeleteExistingResources">Specifies whether to delete the pFileName parameter's existing resources.</param>
        /// <returns>If the function succeeds, the return value is a handle that can be used by the UpdateResource and EndUpdateResource functions.</returns>
        [DllImport("kernel32.dll", EntryPoint = "BeginUpdateResourceW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr BeginUpdateResource(string pFileName, bool bDeleteExistingResources);

        /// <summary>
        /// Commits or discards changes made prior to a call to UpdateResource.
        /// </summary>
        /// <param name="hUpdate">A module handle returned by the BeginUpdateResource function, and used by UpdateResource, referencing the file to be updated.</param>
        /// <param name="fDiscard">Specifies whether to write the resource updates to the file. If this parameter is TRUE, no changes are made. If it is FALSE, the changes are made: the resource updates will take effect.</param>
        /// <returns>Returns TRUE if the function succeeds; FALSE otherwise.</returns>
        [DllImport("kernel32.dll", EntryPoint = "EndUpdateResourceW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EndUpdateResource(IntPtr hUpdate, bool fDiscard);
    }
}