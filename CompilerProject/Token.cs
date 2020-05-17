using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerProject
{
    public enum Type
    {
        T_DATATYPEINT, T_DATATYPEFLOAT, T_DATATYPESTRING, T_IF, T_ELSE, T_ELSEIF, T_UNTIL, T_READ, T_RETURN, T_WRITE, T_ENDLINE, T_END, T_CONSTANT, T_PROGRAM, T_REPEATSTATEMENT, T_ASSIGNMENTOPERATOR, T_IDENTIFIER, T_SEMICOLON, T_THEN,
        T_PLUSOPERATOR, T_MINUSOPERATOR, T_EQUALTO, T_MULTIPLICATIONOPERATOR, T_LESSTHAN, T_DIVISIONOPERATOR, T_GREATERTHAN, T_LEFTCURLYBRACKETS, T_RIGHTCURLYBRACKETS,
        T_LEFTPARENTHESES, T_RIGHTPARENTHESES, T_COMMA, T_NOTEQUAL, T_AND, T_OR, T_COMMENT, T_MAIN, T_ERROR, T_NUMBER, T_STRING, T_FUNCTIONCALL, T_FUNCTIONDECLARATION, T_NEWLINE
    }
    public class Token
    {
        public string input;
        public Type type;
        public Token() { } //constractor mlnash da3wa beeh
        public Token(string inp, Type typ)
        {
            this.input = inp;
            this.type = typ;
        }


    }
}
