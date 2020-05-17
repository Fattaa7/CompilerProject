using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace CompilerProject
{
    class ScannerCompiler
    {
        public string tinyCode = "";
        public Token last;
        public Dictionary<string, Type> data = new Dictionary<string, Type>
        {
            {"int",Type.T_DATATYPEINT},{"float",Type.T_DATATYPEFLOAT},{"string",Type.T_DATATYPESTRING},{"if",Type.T_IF},{"else",Type.T_ELSE},
            {"elseif",Type.T_ELSEIF},{"until",Type.T_UNTIL},{"read",Type.T_READ},{"return",Type.T_RETURN},{"endl",Type.T_ENDLINE},
            {"end",Type.T_END},{"constant",Type.T_CONSTANT},{"program",Type.T_PROGRAM},{"repeat",Type.T_REPEATSTATEMENT},{":=",Type.T_ASSIGNMENTOPERATOR},
            {"<>",Type.T_NOTEQUAL},{"&&",Type.T_AND},{"||",Type.T_OR},{"main",Type.T_MAIN},{"write",Type.T_WRITE},{"then",Type.T_THEN}
        };
        public Dictionary<Char, Type> operators = new Dictionary<char, Type>{{';',Type.T_SEMICOLON},{'+',Type.T_PLUSOPERATOR},{'-',Type.T_MINUSOPERATOR},{'*',Type.T_MULTIPLICATIONOPERATOR},{'<',Type.T_LESSTHAN},{'/',Type.T_DIVISIONOPERATOR},
            {'>',Type.T_GREATERTHAN},{'=',Type.T_EQUALTO},{'{',Type.T_LEFTCURLYBRACKETS},{'(',Type.T_LEFTPARENTHESES},{')',Type.T_RIGHTPARENTHESES},{'}',Type.T_RIGHTCURLYBRACKETS},{',',Type.T_COMMA},
            };
        public Type typeassign(string s)  // return type for lexeme
        {
            if (data.ContainsKey(s)) return data[s];
            return Type.T_IDENTIFIER;
        }
        public ScannerCompiler(string tiny)
        { // read tiny code
            this.tinyCode = tiny;
        }
        public List<Token> tokens = new List<Token>();
        public string lexeme = "";
        public ScannerCompiler() { }
        public void addtotokens(string s, Type t)
        {
            Token to = new Token(s, t);
            tokens.Add(to);
            last = new Token(s, t);
            lexeme = "";
        }
        public void scan()
        {
            for (int i = 0; i < tinyCode.Length; i++)
            {
                if (Char.IsLetterOrDigit(tinyCode[i]) || tinyCode[i] == '_')
                {
                    if (Char.IsLetter(tinyCode[i]) || tinyCode[i] == '_')
                    {
                        int j = i;
                        while (j < tinyCode.Length && (Char.IsLetterOrDigit(tinyCode[j]) || tinyCode[j] == '_'))
                        {
                            lexeme += tinyCode[j];
                            j++;
                        }
                        addtotokens(lexeme, typeassign(lexeme));
                        i = j - 1;
                    }
                    else
                    {
                        int j = i;
                        while (j < tinyCode.Length && (Char.IsDigit(tinyCode[j]) || tinyCode[j] == '.'))
                        {
                            lexeme += tinyCode[j];
                            j++;
                        }
                        if (lexeme.Count(x => x == '.') > 1)
                        {
                            tokens.Clear();
                            addtotokens(lexeme, Type.T_ERROR);
                            break;
                        }
                        else
                        {


                            if (last.type == Type.T_IF || last.type == Type.T_RIGHTCURLYBRACKETS
                             || last.type == Type.T_AND || last.type == Type.T_ASSIGNMENTOPERATOR || last.type == Type.T_COMMA
                             || last.type == Type.T_DIVISIONOPERATOR || last.type == Type.T_ELSE || last.type == Type.T_ELSEIF
                             || last.type == Type.T_EQUALTO || last.type == Type.T_GREATERTHAN || last.type == Type.T_LEFTCURLYBRACKETS
                             || last.type == Type.T_LESSTHAN || last.type == Type.T_MINUSOPERATOR || last.type == Type.T_MULTIPLICATIONOPERATOR
                             || last.type == Type.T_NOTEQUAL || last.type == Type.T_OR || last.type == Type.T_PLUSOPERATOR || last.type == Type.T_IDENTIFIER
                             || last.type == Type.T_RETURN)
                            {
                                {
                                    addtotokens(lexeme, Type.T_NUMBER);
                                    i = j - 1;
                                }
                            } 
                            else
                            {
                                tokens.Clear();
                                addtotokens("identifier can't begin with a number", Type.T_ERROR);
                                
                                break;
                            }

                            }
                    }
                }
                else if (tinyCode[i] == '"')
                {
                    int j = i;
                    do
                    {
                        lexeme += tinyCode[j];
                        j++;
                    } while (j < tinyCode.Length && tinyCode[j] != '"');
                    if (j == tinyCode.Length && tinyCode[j - 1] != '"') 
                    { 
                        tokens.Clear();
                        addtotokens(lexeme, Type.T_ERROR);
                        break;
                    }
                    else
                    {
                        lexeme += tinyCode[j];
                        addtotokens(lexeme, Type.T_STRING);
                    }
                    i = j;
                }

                else if (i + 1 < tinyCode.Length && (tinyCode[i] == '/' && tinyCode[i + 1] == '*'))
                {
                    int j = i;
                    lexeme += tinyCode[j];
                    lexeme += tinyCode[j + 1];
                    j += 2;
                    while (j + 1 < tinyCode.Length && (tinyCode[j] != '*' && tinyCode[j + 1] != '/'))
                    {
                        lexeme += tinyCode[j];
                        j++;
                    }
                    if (j + 1 == tinyCode.Length)
                    {
                        lexeme += tinyCode[j];
                        addtotokens(lexeme, Type.T_ERROR);
                        tokens.Clear();
                        addtotokens(lexeme, Type.T_ERROR);
                        break;
                    }
                    else
                    {
                        lexeme += tinyCode[j];
                        lexeme += tinyCode[j + 1];
                        addtotokens(lexeme, Type.T_COMMENT); i = j + 1;
                    }
                }
                else if (tinyCode[i] == '(')
                {
                    lexeme += tinyCode[i];
                    tokens.Add(new Token(lexeme, Type.T_LEFTPARENTHESES));
                    lexeme = "";

                    if (last != null && last.type == Type.T_IDENTIFIER)
                    {
                        i++;
                        int j = i;
                        while (j < tinyCode.Length && (Char.IsLetterOrDigit(tinyCode[j]) || tinyCode[j] == '_'))
                        {
                            lexeme += tinyCode[j];
                            j++;
                        }
                        if (typeassign(lexeme) == Type.T_IDENTIFIER) tokens[tokens.Count - 2].type = Type.T_IDENTIFIER;
                        else tokens[tokens.Count - 2].type = Type.T_IDENTIFIER;
                        lexeme = "";
                        i--;
                    }
                    else
                    {
                    }

                }
                else if (tinyCode[i] == '|' && i + 1 < tinyCode.Length && (tinyCode[i + 1] == '|')) { lexeme += "||"; addtotokens(lexeme, Type.T_OR); i++; }
                else if (tinyCode[i] == '&' && i + 1 < tinyCode.Length && (tinyCode[i + 1] == '&')) { lexeme += "&&"; addtotokens(lexeme, Type.T_AND); i++; }
                else if (tinyCode[i] == ':' && i + 1 < tinyCode.Length && (tinyCode[i + 1] == '=')) { lexeme += ":="; addtotokens(lexeme, Type.T_ASSIGNMENTOPERATOR); i++; }

                else if (operators.ContainsKey(tinyCode[i]))
                {
                    if (tinyCode[i] == '<' && i + 1 < tinyCode.Length && (tinyCode[i + 1] == '>')) { lexeme += "<>"; addtotokens(lexeme, Type.T_NOTEQUAL); i++; }
                    else
                    {
                        lexeme += tinyCode[i];
                        addtotokens(lexeme, operators[tinyCode[i]]);
                    }
                }
                else if (tinyCode[i] == ' ' || tinyCode[i] == '\n')
                {
                    if (tinyCode[i] == '\n') tokens.Add(new Token("\n", Type.T_NEWLINE));
                }
                else
                {
                    lexeme += tinyCode[i];
                    tokens.Clear();
                    addtotokens(lexeme, Type.T_ERROR);
                    break;
                }

            }
        }
        

    }
}
