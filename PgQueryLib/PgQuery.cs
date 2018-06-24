using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
[assembly: InternalsVisibleTo("PgQueryTest")]

namespace PgQueryLib.Native
{
	internal unsafe struct PgQueryError
	{
		public byte* message;
		public byte* funcname;
		public byte* filename;
		public int lineno;
		public int cursorpos;
		public byte* context;
	}

	internal unsafe struct PgQueryParseResult
	{
		public byte* parse_tree;
		public byte* stderr_buffer;
		public PgQueryError* error;
	}

	internal unsafe struct PgQueryPlpgsqlParseResult
	{
		public byte* plpgsql_funcs;
		public PgQueryError* error;
	}

	internal unsafe struct PgQueryFingerprintResult
	{
		public byte* hexdigest;
		public byte* stderr_buffer;
		PgQueryError* error;
	}

	internal unsafe struct PgQueryNormalizeResult
	{
		public byte* normalized_query;
		public PgQueryError* error;
	}

	internal static class PgQuery
	{
		[DllImport("libpg_query", CallingConvention = CallingConvention.Cdecl, EntryPoint = "pg_query_normalize")]
		public extern unsafe static PgQueryNormalizeResult Normalize(byte* input);

		[DllImport("libpg_query", CallingConvention = CallingConvention.Cdecl, EntryPoint = "pg_query_parse")]
		public extern unsafe static PgQueryParseResult Parse(byte* input);

		[DllImport("libpg_query", CallingConvention = CallingConvention.Cdecl, EntryPoint = "pg_query_parse_plpgsql")]
		public extern unsafe static PgQueryPlpgsqlParseResult ParsePlpgsql(byte* input);

		[DllImport("libpg_query", CallingConvention = CallingConvention.Cdecl, EntryPoint = "pg_query_fingerprint")]
		public extern unsafe static PgQueryFingerprintResult Fingerprint(byte* input);

		[DllImport("libpg_query", CallingConvention = CallingConvention.Cdecl, EntryPoint = "pg_query_free_normalize_result")]
		public extern unsafe static void FreeNormalize(PgQueryNormalizeResult input);

		[DllImport("libpg_query", CallingConvention = CallingConvention.Cdecl, EntryPoint = "pg_query_free_parse_result")]
		public extern unsafe static void FreeParse(PgQueryParseResult input);

		[DllImport("libpg_query", CallingConvention = CallingConvention.Cdecl, EntryPoint = "pg_query_free_plpgsql_parse_result")]
		public extern unsafe static void FreeParsePlpgsql(PgQueryPlpgsqlParseResult input);

		[DllImport("libpg_query", CallingConvention = CallingConvention.Cdecl, EntryPoint = "pg_query_free_fingerprint_result")]
		public extern unsafe static void FreeFingerprint(PgQueryFingerprintResult input);
	}
}
