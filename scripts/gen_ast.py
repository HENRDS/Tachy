from mako.template import Template
from pathlib import Path
from typing import get_args, get_origin
import re
import logging


class AstBuilder:
    def __init__(self, namespace: str, root: str) -> None:
        self.namespace = namespace
        self.root = root
        self.classes = {}
        self.usings = set()

    def using(self, *args):
        self.usings |= set(args)

    def add_class(self, name: str, **kwargs: str):
        self.classes[name] = kwargs


def build_expr():
    xp = "Expression"
    b = AstBuilder("Tachy.Ast", xp)
    b.using(
        "System",
        "System.Collections.Generic"
    )
    b.add_class("Term", Value="Token")
    b.add_class("Unary", Operator="Token", Rhs=xp)
    b.add_class("Binary", Operator="Token", Lhs=xp, Rhs=xp)
    b.add_class("")
    return b


def main():
    templ = Template(filename=str(Path("../Templates/ast.mako").resolve()))
    b = build_expr()
    print(templ.render(namespace=b.namespace, root=b.root, classes=b.classes, usings=b.usings))




if __name__ == "__main__":
    main()
