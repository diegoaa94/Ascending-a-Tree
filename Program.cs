using System;
using System.Collections.Generic;

public class Node {
    private int weight;
    private Node left, right;
    public Node(int weight) {
        this.weight = weight;
        left = right = null;
    }

    public int getWeight() {
        return this.weight;
    }

    public void setLeft(ref Node left) {
        this.left = left;
    }

    public void setRight(ref Node right) {
        this.right = right;
    }

    public Node getLeft() {
        return this.left;
    }

    public Node getRight()
    {
        return this.right;
    }
}

class Program {
    public static List<int> GetOrderedWeights(ref Node tree) {

        List<int> orderedWeights = new List<int>();

        GetWeights(ref tree, ref orderedWeights);
        OrderWeights(ref orderedWeights);

        return orderedWeights;
    }

    private static void GetWeights(ref Node node, ref List<int> weights) {
        weights.Add(node.getWeight());
        Node left = node.getLeft();
        Node right = node.getRight();

        if (left != null) {
            GetWeights(ref left, ref weights);
        }

        if (right != null) {
            GetWeights(ref right, ref weights);
        }
    }

    private static void OrderWeights(ref List<int> weights) {

        bool ordered = false;
        int temp;

        while (!ordered) {
            ordered = true;
            for (int i = 0; i < weights.Count - 1; i++) {
                if (weights[i] > weights[i + 1]) {
                    temp = weights[i];
                    weights[i] = weights[i + 1];
                    weights[i + 1] = temp;
                    ordered = false;
                }
            }
        }
    }


    static void Main(string[] args)
    {
        Node node8 = new Node(8);
        Node node6 = new Node(6);
        Node node1 = new Node(1);
        Node node5 = new Node(5);
        Node node2 = new Node(2);
        Node node7 = new Node(7);
        Node node3 = new Node(3);

        node8.setLeft(ref node6);
        node8.setRight(ref node1);

        node6.setLeft(ref node5);
        node6.setRight(ref node2);

        node1.setLeft(ref node7);
        node1.setRight(ref node3);

        List<int> weights = GetOrderedWeights(ref node8);

        foreach (int weight in weights) {
            Console.WriteLine(weight);
        }
    }
}
