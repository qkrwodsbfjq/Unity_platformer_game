class TreeNode:

    def __init__(self, info):
        self.info = info
        self.left = None
        self.right = None

class BST():

    def __init__(self):
        self.root = None
        self.order_list = []

    def is_empty(self):
        return (self.root == None)

    def count_nodes(self, tree):
        ''''''

    def length_is(self):
        return self.count_nodes(self.root)

    def insert(self, item):
        self.root = self.insert_item(self.root, item)
        return self.root is not None

    def insert_item(self, node, item):
        if node is None:
            node = TreeNode(item)
        else:
            if item <= node.info:
                node.left = self.insert_item(node.left, item)
            else:
                node.right = self.insert_item(node.right, item)
        return node


    def inorder(self, node):
        def _in_order_traversal(root):
            if root is None:
                pass
            else:
                _in_order_traversal(root.left)
                print(root.info)
                _in_order_traversal(root.right)
        _in_order_traversal(self.root)

    def preorder(self, node):
        def _pre_order_traversal(root):
            if root is None:
                pass
            else:
                print(root.info)
                _pre_order_traversal(root.left)
                _pre_order_traversal(root.right)
        _pre_order_traversal(self.root)

    def postorder(self, node):
        def _post_order_traversal(root):
            if root is None:
                pass
            else:
                _post_order_traversal(root.left)
                _post_order_traversal(root.right)
                print(root.info)
        _post_order_traversal(self.root)

    def delete(self, item):
        self.root, deleted = self.delete_node(self.root, item)
        return deleted

    def delete_node(self, current, item):
        if current is None:
            return current, False

        deleted = False
        if item == current.info:
            deleted = True
            if current.left and current.right:

                parent, child = current, current.right
                while child.left is not None:
                    parent, child = child, child.left
                child.left = current.left
                if parent != current:
                    parent.left = child.right
                    child.right = current.right
                current = child
            elif current.left or current.right:
                current = current.left or current.right
            else:
                current = None
        elif item < current.info:
            current.left, deleted = self.delete_node(current.left, item)
        else:
            current.right, deleted = self.delete_node(current.right, item)
        return current, deleted

    def get_predecessor(tree, data):
        '''[9]'''
