﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Kusto.Language.Symbols;

namespace BabyKusto.Core.Evaluation.BuiltIns.Impl
{
    internal class MakeSetIfIntFunctionImpl : IAggregateImpl
    {
        public ScalarResult Invoke(ITableChunk chunk, ColumnarResult[] arguments)
        {
            Debug.Assert(arguments.Length == 2 || arguments.Length == 3);
            var valuesColumn = (Column<int?>)arguments[0].Column;
            var predicatesColumn = (Column<bool?>)arguments[1].Column;
            Debug.Assert(valuesColumn.RowCount == predicatesColumn.RowCount);

            long maxSize = long.MaxValue;
            if (arguments.Length == 3)
            {
                var maxSizeColumn = (Column<long?>)arguments[2].Column;
                Debug.Assert(valuesColumn.RowCount == maxSizeColumn.RowCount);

                if (maxSizeColumn.RowCount > 0)
                {
                    maxSize = maxSizeColumn[0] ?? long.MaxValue;
                }
            }

            var set = new HashSet<int>();
            for (int i = 0; i < valuesColumn.RowCount; i++)
            {
                if (predicatesColumn[i] == true)
                {
                    var v = valuesColumn[i];
                    if (v.HasValue)
                    {
                        set.Add(v.Value);
                        if (set.Count >= maxSize)
                        {
                            break;
                        }
                    }
                }
            }

            return new ScalarResult(ScalarTypes.Dynamic, JsonArrayHelper.From(set));
        }
    }

    internal class MakeSetIfLongFunctionImpl : IAggregateImpl
    {
        public ScalarResult Invoke(ITableChunk chunk, ColumnarResult[] arguments)
        {
            Debug.Assert(arguments.Length == 2 || arguments.Length == 3);
            var valuesColumn = (Column<long?>)arguments[0].Column;
            var predicatesColumn = (Column<bool?>)arguments[1].Column;
            Debug.Assert(valuesColumn.RowCount == predicatesColumn.RowCount);

            long maxSize = long.MaxValue;
            if (arguments.Length == 3)
            {
                var maxSizeColumn = (Column<long?>)arguments[2].Column;
                Debug.Assert(valuesColumn.RowCount == maxSizeColumn.RowCount);

                if (maxSizeColumn.RowCount > 0)
                {
                    maxSize = maxSizeColumn[0] ?? long.MaxValue;
                }
            }

            var set = new HashSet<long>();
            for (int i = 0; i < valuesColumn.RowCount; i++)
            {
                if (predicatesColumn[i] == true)
                {
                    var v = valuesColumn[i];
                    if (v.HasValue)
                    {
                        set.Add(v.Value);
                        if (set.Count >= maxSize)
                        {
                            break;
                        }
                    }
                }
            }

            return new ScalarResult(ScalarTypes.Dynamic, JsonArrayHelper.From(set));
        }
    }

    internal class MakeSetIfDoubleFunctionImpl : IAggregateImpl
    {
        public ScalarResult Invoke(ITableChunk chunk, ColumnarResult[] arguments)
        {
            Debug.Assert(arguments.Length == 2 || arguments.Length == 3);
            var valuesColumn = (Column<double?>)arguments[0].Column;
            var predicatesColumn = (Column<bool?>)arguments[1].Column;
            Debug.Assert(valuesColumn.RowCount == predicatesColumn.RowCount);

            long maxSize = long.MaxValue;
            if (arguments.Length == 3)
            {
                var maxSizeColumn = (Column<long?>)arguments[2].Column;
                Debug.Assert(valuesColumn.RowCount == maxSizeColumn.RowCount);

                if (maxSizeColumn.RowCount > 0)
                {
                    maxSize = maxSizeColumn[0] ?? long.MaxValue;
                }
            }

            var set = new HashSet<double>();
            for (int i = 0; i < valuesColumn.RowCount; i++)
            {
                if (predicatesColumn[i] == true)
                {
                    var v = valuesColumn[i];
                    if (v.HasValue)
                    {
                        set.Add(v.Value);
                        if (set.Count >= maxSize)
                        {
                            break;
                        }
                    }
                }
            }

            return new ScalarResult(ScalarTypes.Dynamic, JsonArrayHelper.From(set));
        }
    }

    internal class MakeSetIfTimeSpanFunctionImpl : IAggregateImpl
    {
        public ScalarResult Invoke(ITableChunk chunk, ColumnarResult[] arguments)
        {
            Debug.Assert(arguments.Length == 2 || arguments.Length == 3);
            var valuesColumn = (Column<TimeSpan?>)arguments[0].Column;
            var predicatesColumn = (Column<bool?>)arguments[1].Column;
            Debug.Assert(valuesColumn.RowCount == predicatesColumn.RowCount);

            long maxSize = long.MaxValue;
            if (arguments.Length == 3)
            {
                var maxSizeColumn = (Column<long?>)arguments[2].Column;
                Debug.Assert(valuesColumn.RowCount == maxSizeColumn.RowCount);

                if (maxSizeColumn.RowCount > 0)
                {
                    maxSize = maxSizeColumn[0] ?? long.MaxValue;
                }
            }

            var set = new HashSet<TimeSpan>();
            for (int i = 0; i < valuesColumn.RowCount; i++)
            {
                if (predicatesColumn[i] == true)
                {
                    var v = valuesColumn[i];
                    if (v.HasValue)
                    {
                        set.Add(v.Value);
                        if (set.Count >= maxSize)
                        {
                            break;
                        }
                    }
                }
            }

            return new ScalarResult(ScalarTypes.Dynamic, JsonArrayHelper.From(set));
        }
    }

    internal class MakeSetIfDateTimeFunctionImpl : IAggregateImpl
    {
        public ScalarResult Invoke(ITableChunk chunk, ColumnarResult[] arguments)
        {
            Debug.Assert(arguments.Length == 2 || arguments.Length == 3);
            var valuesColumn = (Column<DateTime?>)arguments[0].Column;
            var predicatesColumn = (Column<bool?>)arguments[1].Column;
            Debug.Assert(valuesColumn.RowCount == predicatesColumn.RowCount);

            long maxSize = long.MaxValue;
            if (arguments.Length == 3)
            {
                var maxSizeColumn = (Column<long?>)arguments[2].Column;
                Debug.Assert(valuesColumn.RowCount == maxSizeColumn.RowCount);

                if (maxSizeColumn.RowCount > 0)
                {
                    maxSize = maxSizeColumn[0] ?? long.MaxValue;
                }
            }

            var set = new HashSet<DateTime>();
            for (int i = 0; i < valuesColumn.RowCount; i++)
            {
                if (predicatesColumn[i] == true)
                {
                    var v = valuesColumn[i];
                    if (v.HasValue)
                    {
                        set.Add(v.Value);
                        if (set.Count >= maxSize)
                        {
                            break;
                        }
                    }
                }
            }

            return new ScalarResult(ScalarTypes.Dynamic, JsonArrayHelper.From(set));
        }
    }

    internal class MakeSetIfStringFunctionImpl : IAggregateImpl
    {
        public ScalarResult Invoke(ITableChunk chunk, ColumnarResult[] arguments)
        {
            Debug.Assert(arguments.Length == 2 || arguments.Length == 3);
            var valuesColumn = (Column<string?>)arguments[0].Column;
            var predicatesColumn = (Column<bool?>)arguments[1].Column;
            Debug.Assert(valuesColumn.RowCount == predicatesColumn.RowCount);

            long maxSize = long.MaxValue;
            if (arguments.Length == 3)
            {
                var maxSizeColumn = (Column<long?>)arguments[2].Column;
                Debug.Assert(valuesColumn.RowCount == maxSizeColumn.RowCount);

                if (maxSizeColumn.RowCount > 0)
                {
                    maxSize = maxSizeColumn[0] ?? long.MaxValue;
                }
            }

            var set = new HashSet<string>();
            for (int i = 0; i < valuesColumn.RowCount; i++)
            {
                if (predicatesColumn[i] == true)
                {
                    var v = valuesColumn[i];
                    if (!string.IsNullOrEmpty(v))
                    {
                        set.Add(v);
                        if (set.Count >= maxSize)
                        {
                            break;
                        }
                    }
                }
            }

            return new ScalarResult(ScalarTypes.Dynamic, JsonArrayHelper.From(set));
        }
    }
}
