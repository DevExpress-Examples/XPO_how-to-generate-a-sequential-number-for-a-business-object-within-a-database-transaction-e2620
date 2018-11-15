<!-- default file list -->
*Files to look at*:

* [frmMain.cs](./CS/ExplicitUnitOfWorkDemo/frmMain.cs) (VB: [frmMain.vb](./VB/ExplicitUnitOfWorkDemo/frmMain.vb))
* [SequenceGenerator.cs](./CS/ExplicitUnitOfWorkDemo/SequenceGenerator.cs) (VB: [SequenceGenerator.vb](./VB/ExplicitUnitOfWorkDemo/SequenceGenerator.vb))
<!-- default file list end -->
# How to generate a sequential number for a business object within a database transaction


<p>This is a general solution, showing how to use the ExplicitUnitOfWork class to generate sequential numbers that can then be used as user-friendly identifiers in documents, as invoice line numbers, etc. Here, as opposed to the solution shown in the <a href="https://www.devexpress.com/Support/Center/p/A2213">How to make user-friendly object identifiers</a> KB Article, the ExplicitUnitOfWork class is used to ensure that the assignment of the sequential number will be a part of a database transaction that results in the successful saving of the document.<br />
Hence, the current solution will also work in a scenario with high-volume of concurrency transactions.</p><p><strong>See also:</strong> <br />
<a href="https://www.devexpress.com/Support/Center/p/A2213">How to make user-friendly object identifiers</a><br />
<a href="https://www.devexpress.com/Support/Center/p/E2829">How to generate and assign a sequential number for a business object within a database transaction, while being a part of a successful saving process (XAF)</a></p>

<br/>


