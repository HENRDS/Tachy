%for using in usings:
using ${using};
%endfor

namespace ${namespace}
{
    public interface I${root}Visitor
    {
    %for name in classes:
        void visit(${name} node);
    %endfor
    }

    public interface I${root}Visitor<T>
    {
    %for name in classes:
        T visit(${name} node);
    %endfor
    }

    public abstract class ${root}
    {
    %for name, props in classes.items():
        public sealed class ${name}: ${root}
        {
        %for prop_name, prop_type in props.items():
            public ${prop_type} ${prop_name} { get; set; }
        %endfor
            public ${name}(${", ".join(f"{t} {n}" for t, n in props.items())})
            {
            %for prop_name in props:
                this.${prop_name} = ${prop_name};
            %endfor
            }
        }
    %endfor
    }
}
