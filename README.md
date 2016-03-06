# FluentLayout

FluentLayout provides an easy, fluent API for creating constraint-based layouts in Xamarin.iOS.

[![Build Status](https://www.bitrise.io/app/3584ad3a37e4084c.svg?token=nxuhVtDms232YxvcvYIW0w)](https://www.bitrise.io/app/3584ad3a37e4084c)

## How To Use

The best way to see FluentLayout in action is to check out the `QuickLayout.Touch` sample project, which contains many examples of creating a variety of layouts.

### Basic Usage

The basic syntax of FluentLayout looks something like this:

```
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
  sNameField.WithSameTop(fNameField));
```

### Advanced Usage

FluentLayout also offers some advanced layout helpers as well, such as the ability to easily lay out views as a vertical stack:

```
View.AddConstraints(
  View.VerticalStackPanelConstraints(
    new Margins(20, 10, 20, 10, 5, 5),                                              
    View.Subviews));
```

When using the `VerticalStackPanelConstraints` helper each constraint added will be assigned a predictable identifier, allowing you to find relevant constraints later on if you need to. These identifiers are in the form of `{containerId}-{viewId}-{constraintDescription}`:

- `containerId` will be the container's `AccessibilityIdentifier` if one is set, and `VerticalStackPanel` if not
- `viewId` will be the subview's `AccessibilityIdentifier` if one is set, and the subview's index in the array if not
- `constraintDescription` will be based on the constraint itself, such as `Bottom`, `Top`, `Width`, etc.