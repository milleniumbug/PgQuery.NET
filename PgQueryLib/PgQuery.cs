using System;
using System.Runtime.InteropServices;

namespace PgQueryLib.Native
{
	internal unsafe struct PgQueryError
	{
		public char* message;
		public char* funcname;
		public char* filename;
		public int lineno;
		public int cursorpos;
		public char* context;
	}

	internal unsafe struct PgQueryParseResult
	{
		public char* parse_tree;
		public char* stderr_buffer;
		public PgQueryError* error;
	}

	internal unsafe struct PgQueryPlpgsqlParseResult
    {
        public char* plpgsql_funcs;
        public PgQueryError* error;
    }

	internal unsafe struct PgQueryFingerprintResult
	{
		public char* hexdigest;
		public char* stderr_buffer;
		PgQueryError* error;
	}

	internal unsafe struct PgQueryNormalizeResult
	{
		public char* normalized_query;
		public PgQueryError* error;
	}

    internal static class PgQuery
    {
		[DllImport("libpg_query.a", CallingConvention = CallingConvention.Cdecl, EntryPoint = "pg_query_normalize")]
		public extern static PgQueryNormalizeResult Normalize(string input);

		[DllImport("libpg_query.a", CallingConvention = CallingConvention.Cdecl, EntryPoint = "pg_query_parse")]
        public extern static PgQueryParseResult Parse(string input);

		[DllImport("libpg_query.a", CallingConvention = CallingConvention.Cdecl, EntryPoint = "pg_query_parse_plpgsql")]
		public extern static PgQueryPlpgsqlParseResult ParsePlpgsql(string input);

		[DllImport("libpg_query.a", CallingConvention = CallingConvention.Cdecl, EntryPoint = "pg_query_fingerprint")]
        public extern static PgQueryFingerprintResult Fingerprint(string input);

		[DllImport("libpg_query.a", CallingConvention = CallingConvention.Cdecl, EntryPoint = "pg_query_free_normalize_result")]
		public extern static PgQueryNormalizeResult FreeNormalize(string input);

		[DllImport("libpg_query.a", CallingConvention = CallingConvention.Cdecl, EntryPoint = "pg_query_free_parse_result")]
        public extern static PgQueryParseResult FreeParse(string input);

		[DllImport("libpg_query.a", CallingConvention = CallingConvention.Cdecl, EntryPoint = "pg_query_free_plpgsql_parse_result")]
        public extern static PgQueryPlpgsqlParseResult FreeParsePlpgsql(string input);

		[DllImport("libpg_query.a", CallingConvention = CallingConvention.Cdecl, EntryPoint = "pg_query_free_fingerprint_result")]
        public extern static PgQueryFingerprintResult FreeFingerprint(string input);
    }
}
