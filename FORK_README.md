# kstreet fork notes:
*Last Updated January 15, 2014*

## QuickLayout provides a fluent API for constraint-based layout in Xamarin.iOS ##

**What Is This Fork In Here For?**

This fork is in the kstreet GitHub account because the fork is the copy that is referenced and currently used with:

- Not currently referenced by my other projects but will likely be used in upcoming iOS projects


**How Fresh Is This?**

This fork was from the slodge account repo with an initial commit in August 2013 which appeared AFTER the July commits on the Mvx Tutorials repo.
Assuming this repo was the most recent and reviewed the minor changes the Tutorials repo had in October 2013 to make sure nothing major had changed.

This fork already had these changes:
[https://github.com/MvvmCross/MvvmCross-Tutorials/commit/4e1a98e8594e5ea8e740418236f494dfd574655f#diff-b4ff7cfefc185ef4544f98fc26bc4f55](https://github.com/MvvmCross/MvvmCross-Tutorials/commit/4e1a98e8594e5ea8e740418236f494dfd574655f#diff-b4ff7cfefc185ef4544f98fc26bc4f55)

TODO: Do we still have to remove dots from Touch Assembly names like this change did?
and these changes:

[https://github.com/MvvmCross/MvvmCross-Tutorials/commit/e560241efe964997de9fa4691a810f6bd00a4fbe](https://github.com/MvvmCross/MvvmCross-Tutorials/commit/e560241efe964997de9fa4691a810f6bd00a4fbe)

seemed mainly related to updating Mvx which this forks has already done in Nov 2013.
 




For original information, see [http://slodge.blogspot.co.uk/2013/07/playing-with-constraints.html](http://slodge.blogspot.co.uk/2013/07/playing-with-constraints.html)

-----

If you've watched any of the N+1 series - [http://mvvmcross.blogspot.com/](http://mvvmcross.blogspot.com/) - then you'll no doubt have seen me writing a lot of repetitive, error-prone layout code like:

       var textView = new UITextField(new RectangleF(10, 100, 300, 30));
       Add(textView);
       textView.InputView = picker;
       var label = new UILabel(new RectangleF(10, 130, 300, 30));
       Add(label);
	   
All of this repetitive, error-prone layout code was... of course... unnecessary.&nbsp; The problem was that I am a dinosaur and sometimes it takes me time to learn what I should be doing...

iOS6 is now almost a year old - and part of iOS6 was a new layout system called **constraints**. The basic idea behind these constraints is that it allows you to specify relationships between the layouts of UIView objects and their attribute values- so that you can, for example, ask one view to set its Top equal to the Bottom of another view. When you do this, then iOS/UIKit will then try to work out the layout for you at runtime.

I've been playing with these today and they are **fabulous** - especially when coupled with the power of C# - expect to see more of them in my demos soon!

One gist of code that really makes this lovely is Frank's Easy Layout DSL - see [http://praeclarum.org/post/45690317491/easy-layout-a-dsl-for-nslayoutconstraint](http://praeclarum.org/post/45690317491/easy-layout-a-dsl-for-nslayoutconstraint)

This expression based library let's you use simple C# statements to define your layout - it's best summarised by code - see his picture which shows how to layout a button and a text box:

![Frank's][1]

For my experiments I decided to see if I could create a Fluent-style API for the same type of effect. I've nothing against the 'Easy Layout DSL' - I just wanted to learn the constraints for myself, plus I wanted to see if using a Fluent approach gave me more composability and reusability.

What I wanted to do was to see if I could define Frank's 'text and button' layout using Fluent code like:


            View.AddConstraints(
                    button.AtTopOf(View).Plus(vPadding),
                    button.AtRightOf(View).Minus(hPadding),
                    button.Width().EqualTo(ButtonWidth),
 
                    text.AtLeftOf(View, hPadding),
                    text.ToLeftOf(button, hPadding),
                    text.WithSameTop(button)
                );

It turned out that it took a bit longer than I had hoped - there were a few gotchas along the way, mainly to do with "TranslateAutoresizingMaskIntoConstraints" - but within a couple of hours I had this working :)

And once I had that working, I then started to play....

**What would a form layout look like?**

[![](http://2.bp.blogspot.com/-wX4OGEiSGZw/Ue0qqXWYWxI/AAAAAAAAA_A/3uXN6JExEe0/s320/quicklayout.png)](http://2.bp.blogspot.com/-wX4OGEiSGZw/Ue0qqXWYWxI/AAAAAAAAA_A/3uXN6JExEe0/s1600/quicklayout.png)

	View.AddConstraints(
	 
		fNameLabel.AtTopOf(View, vMargin),
		fNameLabel.AtLeftOf(View, hMargin),
		fNameLabel.ToLeftOf(sNameLabel, hMargin),
	 
		sNameLabel.WithSameTop(fNameLabel),
		sNameLabel.AtRightOf(View, hMargin),
		sNameLabel.WithSameWidth(fNameLabel),
	 
		fNameField.WithSameWidth(fNameLabel),
		fNameField.WithSameLeft(fNameLabel),
		fNameField.Below(fNameLabel, vMargin),
	 
		sNameField.WithSameLeft(sNameLabel),
		sNameField.WithSameWidth(sNameLabel),
		sNameField.WithSameTop(fNameField),
	 
		numberLabel.WithSameLeft(fNameLabel),
		numberLabel.ToLeftOf(streetLabel, hMargin),
		numberLabel.Below(fNameField, vMargin),
		numberLabel.WithRelativeWidth(streetLabel, 0.3f),
	 
		streetLabel.WithSameTop(numberLabel),
		streetLabel.AtRightOf(View, hMargin),
	 
		numberField.WithSameLeft(numberLabel),
		numberField.WithSameWidth(numberLabel),
		numberField.Below(numberLabel, vMargin),
	 
		streetField.WithSameLeft(streetLabel),
		streetField.WithSameWidth(streetLabel),
		streetField.WithSameTop(numberField),
	 
		townLabel.WithSameLeft(fNameLabel),
		townLabel.WithSameRight(streetLabel),
		townLabel.Below(numberField, vMargin),
	 
		townField.WithSameLeft(townLabel),
		townField.WithSameWidth(townLabel),
		townField.Below(townLabel, vMargin),
	 
		zipLabel.WithSameLeft(fNameLabel),
		zipLabel.WithSameWidth(townLabel),
		zipLabel.Below(townField, vMargin),
	 
		zipField.WithSameLeft(townLabel),
		zipField.WithSameWidth(zipLabel),
		zipField.Below(zipLabel, vMargin),
	 
		debug.WithSameLeft(townLabel),
		debug.WithSameWidth(zipLabel),
		debug.AtBottomOf(View, vMargin)
	 
	); 

... although I think there are some opportunities to shorten that code and perhaps also to use some code-based hints too! 

**Could I create a generic vertical scrolling StackPanel/LinearLayout?**

[![](http://4.bp.blogspot.com/-g59dSQE1JeA/Ue0qHXI-qSI/AAAAAAAAA-4/KF1QKPtcrTc/s320/constraints.png)](http://4.bp.blogspot.com/-g59dSQE1JeA/Ue0qHXI-qSI/AAAAAAAAA-4/KF1QKPtcrTc/s1600/constraints.png)

	public static IEnumerable<FluentLayout> 
		   VerticalStackPanelConstraints(
			  this UIView parentView, 
			  Margins margins,
			  params UIView[] views)
	 {
		 margins = margins ?? new Margins();
	 
		 UIView previous = null;
		 foreach (var view in views)
		 {
			yield return view.Left()
							 .EqualTo()
							 .LeftOf(parentView)
							 .Plus(margins.Left);
			yield return view.Width()
							 .EqualTo()
							 .WidthOf(parentView)
							 .Minus(margins.Right + margins.Left);
			if (previous != null)
			   yield return view.Top()
								.EqualTo()
								.BottomOf(previous)
								.Plus(margins.Top);
			else
			   yield return view.Top()
								.EqualTo()
								.TopOf(parentView)
								.Plus(margins.Top);
			previous = view;
		 }
		 if (parentView is UIScrollView)
			yield return previous.Bottom()
								 .EqualTo()
								 .BottomOf(parentView)
								 .Minus(margins.Bottom);
	 }

**Adaptive!**

One key thing to note about these constraint-based UIs is that they are **adaptive** - e.g. when you rotate the phone then the layout adapts:

[![](http://4.bp.blogspot.com/-QPYBmqKdOU0/Ue0sawecVPI/AAAAAAAAA_Q/SPJwrjTI9zs/s320/form2.png)](http://4.bp.blogspot.com/-QPYBmqKdOU0/Ue0sawecVPI/AAAAAAAAA_Q/SPJwrjTI9zs/s1600/form2.png)

[![](http://4.bp.blogspot.com/-cb6mOm4F-28/Ue0scetnOjI/AAAAAAAAA_Y/FXQg3PbCB8c/s320/stackpanelH.png)](http://4.bp.blogspot.com/-cb6mOm4F-28/Ue0scetnOjI/AAAAAAAAA_Y/FXQg3PbCB8c/s1600/stackpanelH.png)

**The code**

License is Ms-PL as per normal.

**A video demo - laying out a tipcalc view**

http://www.youtube.com/embed/5BAuOq-FcJM

**More?**

With all this said and done, whether or not you prefer declarative or [Imperative](http://blog.xamarin.com/creating-imperative-uis-in-c/) UI code is very much a matter of taste... but one question that I'm wondering at the moment is whether I could use the same UI code to create layouts in different environments - whether the same `AtTopOf`, `ToLeftOf` type calls could be used to generate UIKit, Xaml or Axml... but that question will have to wait for another day....


  [1]: http://i.stack.imgur.com/WBerH.png