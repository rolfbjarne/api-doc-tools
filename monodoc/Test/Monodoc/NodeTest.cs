using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using NUnit.Framework;

using Monodoc;

namespace MonoTests.Monodoc
{
	[TestFixture]
	public class NodeTest
	{
		string BaseDir
		{
			get
			{
				var baseDir = "../../monodoc_test/";
				var assemblyLocation = this.GetType ().Assembly.Location;
				return Path.GetFullPath (
					Path.Combine (
						Path.GetDirectoryName (assemblyLocation),
						baseDir));
			}
		}

		[Test]
		public void LegacyNodesTest_30 ()
		{
			TestLegacyNodesSameAsChildNodes ("tree-from-3-0.tree");
		}

		[Test]
		public void LegacyNodesTest_210 ()
		{
			TestLegacyNodesSameAsChildNodes ("tree-from-2-10.tree");
		}

		[Test]
		public void LegacyNodesTest_30old ()
		{
			TestLegacyNodesSameAsChildNodes ("tree-from-3-0-old.tree");
		}

		void TestLegacyNodesSameAsChildNodes (string treeFileName)
		{
			var filePath = Path.Combine (BaseDir, "trees", treeFileName);
			var tree = new Tree (null, filePath);
			CollectionAssert.AreEqual (tree.RootNode.ChildNodes, tree.RootNode.Nodes);
		}
	}
}
