using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace DotNetReactAndGraphQL.GraphQL
{
    public class AuthorInputType : InputObjectGraphType
    {
        public AuthorInputType()
        {
            Name = "authorInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}
